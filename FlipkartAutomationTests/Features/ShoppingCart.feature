Feature: ShoppingCart
			

@Add
Scenario Outline: Addding Products To Shopping Cart
	Given The User On Flipkart Application
	When the the User Search For '<Product>'
	When User Clicked On '<Product Link>'
	And Seleced Add to Cart
	Then the User Should See <Total Products Count> In His Cart
	Examples: 
		| Product             | Product Link     | Total Products Count |
		| Rolex Watch Men     | WATFKNSP2YSVGUZY | 1                    |
		| fastrack sunglasses | SGLFG94CQZ4AYS2F | 2                    |

@Remove
Scenario Outline: Removing Products From Shopping Cart
	Given User Has Products In His Cart
	When He Removed '<product>' from Cart
	Then Product Should Be Removed Successfully
	Examples: 
		| product     |
		| Stylishrolex Watch |
