#include "stdafx.h"
#include "MsgQueue.h"

using namespace Mongo;

MsgQueue::MsgQueue() : mHead(&mStub), mTail(&mStub)
{
	mOffset = offsetof(struct MsgEntry, mNodeEntry);
}

void MsgQueue::Push(MsgEntry* newData)
{
	NodeEntry* prevNode = (NodeEntry*) InterlockedExchangePointer((volatile PVOID*) &mHead, (void*) &( newData->mNodeEntry ));
	prevNode->mNext = &( newData->mNodeEntry );
}

MsgEntry* MsgQueue::Pop()

{
	NodeEntry* tail = mTail;
	NodeEntry* next = tail->mNext;

	if(tail == &mStub)
	{
		/// in case of empty
		if(nullptr == next)
			return nullptr;

		/// first pop
		mTail = next;
		tail = next;
		next = next->mNext;
	}

	/// in most cases...
	if(next)
	{
		mTail = next;
		return reinterpret_cast<MsgEntry*>( reinterpret_cast<int64_t>(tail) -mOffset );
	}

	NodeEntry* head = mHead;
	if(tail != head)
		return nullptr;

	/// last pop
	mStub.mNext = nullptr;
	NodeEntry* prevNode = (NodeEntry*) InterlockedExchangePointer((volatile PVOID*) &mHead, (void*) &mStub);
	prevNode->mNext = &mStub;

	next = tail->mNext;
	if(next)
	{
		mTail = next;
		return reinterpret_cast<MsgEntry*>( reinterpret_cast<int64_t>(tail) -mOffset );
	}

	return nullptr;
}

