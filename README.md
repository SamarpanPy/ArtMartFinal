🎯 ArtMart Backend Flow — Step-by-Step
1. User Registration
Endpoint: POST /api/Auth/register

Roles: "Admin" or "Customer" (pass role in request)

User provides: email, password, role

Server validates and creates user with hashed password

User stored with role in the database

2. User Login
Endpoint: POST /api/Auth/login

User provides email & password

Server verifies credentials

If valid, server issues a JWT token with role claims

Client stores JWT for future requests

3. Admin Functionality
a. Manage Categories
Add Category — POST /api/Category (Admin only)

View Categories — GET /api/Category (Public)

Admin creates categories first (e.g., Vintage, Abstract).

b. Manage Products
Add Product — POST /api/Product (Admin only, must include existing categoryId)

Update Product — PUT /api/Product/{id} (Admin only)

Delete Product — DELETE /api/Product/{id} (Admin only)

View Products — GET /api/Product (Public)

4. Customer Functionality
a. Browse Products & Categories
Anyone (even without login) can view categories and product lists

GET /api/Category

GET /api/Product

b. Add to Cart
Endpoint: POST /api/Cart/add/{productId}

Role: Customer only (JWT required)

Server adds product to that user's cart

c. View Cart
Endpoint: GET /api/Cart

Role: Customer only

Server returns all items in customer’s cart with quantity & product details

d. Remove from Cart
Endpoint: DELETE /api/Cart/remove/{productId}

Role: Customer only

e. Add to Wishlist
Endpoint: POST /api/Wishlist/{productId}

Role: Customer only

f. View Wishlist
Endpoint: GET /api/Wishlist

Role: Customer only

g. Ratings & Reviews
View Ratings: GET /api/Rating/{productId} — anyone

Add/Update Rating: POST /api/Rating/{productId} (Customer only)

Only logged-in customers can add or update ratings for products

h. Place Order (Checkout)
Endpoint: POST /api/Order/place

Role: Customer only

Server converts cart items to an order, saves snapshot of product details & total amount

Clears the customer’s cart after order placement

i. View Orders
Endpoint: GET /api/Order/my

Role: Customer only

Returns all orders placed by the logged-in customer

5. Anonymous User (No JWT)
Can only view products, categories, and ratings

Cannot add to cart, wishlist, rate, or order
