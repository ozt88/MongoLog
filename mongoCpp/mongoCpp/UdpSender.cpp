#include "stdafx.h"
#include "UdpSender.h"

UdpSender::UdpSender()
{
}

UdpSender::~UdpSender()
{
	WSACleanup();
}

bool UdpSender::Init(const char* addr, int port)
{
	WSADATA wsaData;
	if(0 != WSAStartup(MAKEWORD(2, 0), &wsaData))
		return false;

	mSocket = WSASocket(AF_INET, SOCK_DGRAM, IPPROTO_UDP, NULL, 0, WSA_FLAG_OVERLAPPED);
	if(mSocket == INVALID_SOCKET)
		return false;

	ZeroMemory(&mAddr, sizeof(mAddr));
	mAddr.sin_port = htons(port);
	mAddr.sin_family = AF_INET;
	mAddr.sin_addr.s_addr = inet_addr(addr);

	mIp = addr;
	mPort = port;

	return true;
}


bool UdpSender::SendMsg(const std::string& msg)
{
	OverlappedUdpContext* context = new OverlappedUdpContext();
	context->mWsaBuf.len = msg.size();
	context->mWsaBuf.buf = context->mData;
	memcpy(context->mData, msg.c_str(), msg.size());
	DWORD sendbytes = 0;
	DWORD flags = 0;

	if(SOCKET_ERROR == WSASendTo(mSocket, &context->mWsaBuf, 1, &sendbytes, flags,
		(const sockaddr*) &mAddr, sizeof(SOCKADDR_IN), (LPWSAOVERLAPPED) context, NULL))
	{
		if(WSAGetLastError() != WSA_IO_PENDING)
		{
			delete context;
			return false;
		}
	}

	return true;
}
