// mongoCpp.cpp : 콘솔 응용 프로그램에 대한 진입점을 정의합니다.
//

#include "stdafx.h"
#include "MongoLog.h"

void ThreadRun(int id);

int _tmain(int argc, _TCHAR* argv[])
{
	
	//Init
	if(!GET_MONGOLOG()->Init("ozt88", "rladusdn1"))
		return false;


	int count = 0;
	std::vector<std::thread> threads;
	//Make Thread...
	for(int i = 0; i < 5; ++i)
	{
		threads.push_back(std::thread(ThreadRun, i));
	}
	for(auto& t : threads)
	{
		t.join();
	}

	//End
	GET_MONGOLOG()->End();
	return 0;
}

void ThreadRun(int id)
{
	auto mongger = GET_MONGOLOG()->GetMongger("Function" + std::to_string(id));

	Mongo::LogLevel level;
	int intValue;
	int dividor;
	float floatValue;
	std::string strValue;
	while(true)
	{
		//Make Datas...
		level = Mongo::LogLevel(rand() % ( (int) Mongo::LogLevel::ALL + 1 ));
		intValue = rand() % 1000;
		dividor = (rand() % 1000) + 1;
		floatValue = (float)intValue / dividor;
		strValue = "int = " + std::to_string(intValue) + " dividor = " + std::to_string(dividor) + " div = " + std::to_string(floatValue);

		//Log!
		mongger->Log(level, {{"int", intValue}, {"float", floatValue}, {"str", strValue}});

		Sleep(100);
	}
}

