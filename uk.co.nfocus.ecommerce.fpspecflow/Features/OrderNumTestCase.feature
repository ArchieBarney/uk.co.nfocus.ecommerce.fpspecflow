﻿@GUI
Feature: OrderNumTestCase

A short summary of the feature

Background: The current webpage is the cart


Scenario: Ensure Order Number is consistent with most recent order
	Given I click on Proceed to Checkout
	And I fill '65 Toon Avenue', 'Newcastle', 'NE3 3AB', '07754 539781' and 'random_example@example.com' into the corresponding fields
	And I place the order assuming check payment is triggered
	When I capture the order number
	Then The same order number should appear at the top of account orders
