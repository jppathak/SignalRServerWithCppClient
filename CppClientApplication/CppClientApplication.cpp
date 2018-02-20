// CppClientApplication.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <sstream>
#include "signalrclient\hub_connection.h"
#include "signalrclient\connection.h"
#include <pplawait.h>

void ReportTrackerJustInTime(const web::json::value& progress)
{
	ucout << U("Completed: ") << progress.as_integer() << std::endl;
}

void GetTrackersWithJustInTimeProgress()
{
	utility::string_t url = U("http://localhost:9000");
	auto connection = std::make_shared<signalr::hub_connection>(url);
	auto proxy = connection->create_hub_proxy(U("TrackingHub"));
	connection->start()
		.then([&proxy, &connection]()
	{
		pplx::task<web::json::value> invoke_task = proxy.invoke<web::json::value>(U("DoLongRunningThingWithJustInTimeProgressAsync"), ReportTrackerJustInTime);
		web::json::value val = invoke_task.get();
		ucout << U("Completed: ") << val.as_string() << std::endl;
		connection->stop();
	}).get();
}

int main()
{
	GetTrackersWithJustInTimeProgress();
    return 0;
}

