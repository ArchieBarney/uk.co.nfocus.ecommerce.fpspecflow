@GUI
Feature: OrderNumTestCase

Test case to ensure a completed order will contain an order number at the top of the accounts order
page

Background: The current webpage is the cart


Scenario: Ensure Order Number is consistent with most recent order
	Given I click on Proceed to Checkout
	And I fill '<street>', '<city>', '<postcode>', '<phoneNumber>' and '<email>' into the corresponding fields
	And I place the order assuming check payment is triggered
	When I capture the order number
	Then The same order number should appear at the top of account orders

Examples: 
	| street         | city      | postcode | phoneNumber  | email                      |
	| 65 Toon Avenue | Newcastle | NE3 3AB  | 07754 539781 | random_example@example.com |

# Logout of the account to end test case