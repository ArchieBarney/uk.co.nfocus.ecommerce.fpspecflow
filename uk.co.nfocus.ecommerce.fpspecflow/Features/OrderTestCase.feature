@GUI
Feature: OrderTestCase

A short summary of the feature

Background: The current webpage is the cart


Scenario: Apply a coupon on the cart
	Given I have entered valid coupon 'edgewords'
	When I click Apply Coupon
	Then '0.15' is taken off the subtotal
	And Total takes into account coupon + shipping