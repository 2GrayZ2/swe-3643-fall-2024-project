@startuml
allowmixing

package "Calculator Logic Module" #lightblue
{
class DescriptiveStatistics {
+ ValidationFunctions
+ LogicFunctions
}

    class LinearRegression {
        + ValidationFunctions
        + LogicFunctions
    }

}

package "Calculator Logic Unit Tests via NUnit" #lightyellow
{
class LogicUnitTests {
+ DescriptiveStatistics_AcceptsValueMeanStdDev_ReturnsZScore()
+ LinearRegression_EmptyList_ReturnsError()
}

LogicUnitTests --> DescriptiveStatistics
LogicUnitTests --> LinearRegression

}

package "Calculator Web Server App" #lightblue
{
class Models
class Views
class Controllers

Controllers --> Views
Controllers --> Models
Controllers --> DescriptiveStatistics
Controllers --> LinearRegression
}

package "Calculator End-To-End Tests via Playwright" #lightyellow {
class CalculatorEndToEndTests {
+ CalculatorUI_ListofValues_CalculatesMean()
+ CalcuatlorUI_EmptyListOfValues_DisplaysError()
+ CalculatorUI_InvalidListOfValues_DisplaysError()
}

    CalculatorEndToEndTests --> Controllers : HTTP Call via\n Headless Browser
}

cloud #yellow {
hide circle
class Browser
Browser <--> Controllers : HTTP Call
}
@enduml