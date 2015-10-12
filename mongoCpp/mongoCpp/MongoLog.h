#pragma once
#include <map>
#include "UdpSender.h"
#include "MsgQueue.h"
#include "Mongger.h"
#define GET_MONGOLOG Mongo::MongoLog::GetInstance

namespace Mongo
{
	class MongoLog
	{
	public:
		static MongoLog* GetInstance();
		bool Init(const std::string& id, const std::string& psw);
		void End();
		void Wait();
		void Run();

		Mongger* GetMongger(const std::string& name);

	private:
		MongoLog() = default;
		~MongoLog() = default;
		bool SendMsg();
		void PushMsg(const std::string& log);

	private:
		UdpSender		mSender;
		std::thread*	mThread;
		MsgQueue		mMsgQueue;
		bool			mIsRunning = false;

		std::string		mId;
		std::string		mPsw;
		std::map<std::string, Mongger*> mMonggers;

		friend Mongger;
	};

}
