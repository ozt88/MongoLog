#pragma once
#include "ObjectPool.h"
namespace Mongo
{
	struct NodeEntry
	{
		NodeEntry() : mNext(nullptr)
		{
		}
		NodeEntry* volatile mNext;
	};

	struct MsgEntry : public ObjectPool < MsgEntry >
	{
		MsgEntry(std::string msg) : mMsg(msg)
		{
		}
		NodeEntry mNodeEntry;
		std::string mMsg;
	};

	class MsgQueue
	{
	public:
		MsgQueue();

		/// mutiple produce
		void Push(MsgEntry* newData);
		/// single consume
		MsgEntry* Pop();

	private:

		NodeEntry* volatile mHead;
		NodeEntry*			mTail;
		NodeEntry			mStub;
		int64_t				mOffset;
	};
}

