@GUI
Feature: CompleteOrderTest

A short summary of the feature

Background: Ensure there are items in the cart and we are logged in
	Given I am logged in as a customer
	And I have added 'Beanie' to my cart


Scenario Outline: Apply a coupon on the cart
	Given I have entered valid coupon '<couponName>'
	When I Apply the Coupon
	Then '<couponPercentage>' is taken off the subtotal
	And Total takes into account coupon + shipping

Examples: 
	| couponName | couponPercentage |
	| edgewords  | 15%				|


Scenario: Ensure Order Number is consistent with most recent order
	Given I click on Proceed to Checkout
	When I fill order details into the corresponding fields
		| Field       | Data                       |
		| FirstName   | Archie                     |
		| Surname     | Barnett                    |
		| Street      | 65 Toon Avenue             |
		| City        | Newcastle                  |
		| Postcode    | NE3 3AB                    |
		| PhoneNumber | 07754 539781               |
		| Email       | random_example@example.com |
	And Cheque Payment is selected
	And I place an order
	Then an Order Number is displayed
	And that Order Number appears in the account order history

# Logout of the account to end test case
