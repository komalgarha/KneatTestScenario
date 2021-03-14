Feature: Filters
Filters for Booking.Com

@starratingfilter
Scenario: Apply Star Rating Filter on the Website
	Given  I launch the website
	When I enter the following details
	| Location |	
	| Limerick |
	When I click Search Button
	When the star rating filter is applied
	Then the following expected result should be displayed.
	| ExpectedHotel   |
	| The Savoy Hotel |
	Then the following not expected result should be displayed.
	| NotExpectedHotel   |
	| George Limerick Hotel |
	Then Close the Browser Instance

@saunafilter
Scenario: Apply Sauna Filter on the Website
	Given  I launch the website
	When I enter the following details
	| Location |	
	| Limerick |
	When I click Search Button
	When the sauna filter is applied
	Then the following expected result should be displayed.
	| ExpectedHotel   |
	| Limerick Strand Hotel |
	Then the following not expected result should be displayed.
	| NotExpectedHotel   |
	| George Limerick Hotel |
	Then Close the Browser Instance
