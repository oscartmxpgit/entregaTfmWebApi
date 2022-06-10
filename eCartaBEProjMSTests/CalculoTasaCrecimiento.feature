Feature: CalculoTasaCrecimiento
	Simple calculator for growth rate

@mytag
Scenario: Calculate Growth Rate
	Given the initial value is 50
	And the final value is 70
	When the growth rate is calculated
	Then the result should be 120