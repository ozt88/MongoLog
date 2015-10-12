#include "stdafx.h"
#include <chrono>
#include "json.h"
#include "Mongger.h"
#include "MongoLog.h"

using namespace std::chrono;
using namespace Mongo;
Mongger::Mongger(const std::string& id, const std::string& psw, const std::string& name)
	:mId(id), mPsw(psw), mName(name)
{
}


Mongger::~Mongger()
{
}

void Mongger::Log(LogLevel level, Message log)
{
	Json::Value root;
	root["UserId"] = mId;
	root["Password"] = mPsw;
	root["Name"] = mName;
	root["Level"] = (int) level;
	root["Time"] = duration_cast<milliseconds>( system_clock::now().time_since_epoch() ).count();

	Json::Value msg;
	for(auto& keyValue : log)
	{
		msg[keyValue.mKey] = keyValue.mValue;
	}
	root["Msg"] = msg;
	Json::StyledWriter writer;
	std::string json = writer.write(root);

	GET_MONGOLOG()->PushMsg(json);
}
