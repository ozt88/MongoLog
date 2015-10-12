#pragma once
#include <string>
#include <vector>

namespace Mongo
{
		enum class LogLevel : int
	{
		FATAL,
		WARN,
		INFO,
		DEBUG,
		ALL,
	};

	struct KeyValue;
	using Message = std::vector < KeyValue > ;

	class Mongger
	{
	public:
		Mongger(const std::string& id, const std::string& psw, const std::string& name);
		~Mongger();

		void Log(LogLevel level, Message log);
		//void Log(LogLevel level, const std::string& log);
	private:
		std::string		mName;
		std::string		mId;
		std::string		mPsw;
	};

	struct KeyValue
	{
		KeyValue(const std::string& key, int value) :mKey(key), mValue(std::to_string(value)){}
		KeyValue(const std::string& key, unsigned value) :mKey(key), mValue(std::to_string(value)){}
		KeyValue(const std::string& key, float value) :mKey(key), mValue(std::to_string(value)){}
		KeyValue(const std::string& key, double value) :mKey(key), mValue(std::to_string(value)){}
		KeyValue(const std::string& key, UINT64 value) :mKey(key), mValue(std::to_string(value)){}
		KeyValue(const std::string& key, INT64 value) :mKey(key), mValue(std::to_string(value)){}
		KeyValue(const std::string& key, const std::string& value) :mKey(key), mValue(value){}

		std::string mKey;
		std::string mValue;

	};
}

