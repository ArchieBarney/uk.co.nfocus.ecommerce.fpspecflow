@GUI
Feature: CouponTestCase

Test case to ensure a coupon can be applied to a cart and it will be reflected in the final
billing calculation

Background: The current webpage is the cart


Scenario: Apply a coupon on the cart
	Given I have entered valid coupon '<couponName>'
	When I click Apply Coupon
	Then <couponValue> is taken off the subtotal
	And Total takes into account coupon + shipping

Examples: 
	| couponName | couponValue |
	| edgewords  | 0.15        |

# Logout of the account to end test case