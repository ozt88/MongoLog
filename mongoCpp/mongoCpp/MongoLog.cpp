#include "stdafx.h"
#include "MongoLog.h"

using namespace Mongo;

MongoLog* MongoLog::GetInstance()
{
	static MongoLog instance;
	return &instance;
}

bool MongoLog::Init(const std::string& id, const std::string& psw)
{
	if(!mSender.Init("127.0.0.1", 12345))
		return false;

	mId = id, mPsw = psw, mIsRunning = true;
	mThread = new std::thread(&MongoLog::Run, this);

	return true;
}

void MongoLog::Wait()
{
	mThread->join();
}

void MongoLog::End()
{
	mIsRunning = false;
	mThread->join();

	for(auto mongger : mMonggers)
	{
		if(mongger.second != nullptr)
		{
			delete mongger.second;
		}
	}
	mMonggers.clear();
}

void MongoLog::Run()
{
	while(true)
	{
		if(!mIsRunning || !SendMsg())
			break;
		Sleep(100);
	}
}

bool MongoLog::SendMsg()
{
	MsgEntry* msg = mMsgQueue.Pop();
	if(msg == nullptr) 
		return true;

	return mSender.SendMsg(msg->mMsg);
}

void MongoLog::PushMsg(const std::string& log)
{	
	MsgEntry* newMsg = new MsgEntry(log);
	mMsgQueue.Push(newMsg);
}

Mongger* MongoLog::GetMongger(const std::string& name)
{
	if(mMonggers.find(name) == mMonggers.end())
	{
		Mongger* newMongger = new Mongger(mId, mPsw, name);
		mMonggers[name] = newMongger;
	}

	return mMonggers[name];
}
