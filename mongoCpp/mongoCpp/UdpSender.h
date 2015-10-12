#pragma once
#include "ObjectPool.h"


class UdpSender
{
public:
	UdpSender();
	~UdpSender();

	bool Init(const char* addr, int port);
	bool SendMsg(const std::string& msg);
	void Update();


private:
	SOCKET		mSocket;
	SOCKADDR_IN mAddr;

	const char* mIp;
	int			mPort = 0;
};

struct OverlappedUdpContext : public ObjectPool < OverlappedUdpContext >
{
	OVERLAPPED	mOverlapped;
	WSABUF		mWsaBuf;
	char		mData[2048];
};

