# MongoLog

## Service abstraction
 * c++에서 json형식의 Log를 남기고 그 내용을 MongoDB에 저장하여
 * 로그 클라이언트에서 저장 로그의 History를 확인할 수 있다.

## SW functions
 * Handle = MongoLog::CreateLog("LogTitle", LogLevel);
  - 접근/중요도 level과 이름을 가진 document 생성 및 핸들 반환
 * MongoLog::Log(Handle, Key, Value ... );
  - 핸들을 사용한 document에 로그 추가(로깅 시간 포함)

## Operation & Development Environment
 * operation environment : Windows 7 이상, mongodb driver(예상), c++ 11이상
 * development environment : Windows 7, mongodb in UNIX server, visual studio 13

## Rough data model
 * LogDoc : Title, Level, Key & Values ...

## Schedule
 * September 1week : Logger Library 설계
 * September 2week : DB환경 구축및 실제 데이터 삽입 테스트
 * September 3week : DB 로그 확인 클라이언트 제작
 * September 4week : 마무리 및 시연
