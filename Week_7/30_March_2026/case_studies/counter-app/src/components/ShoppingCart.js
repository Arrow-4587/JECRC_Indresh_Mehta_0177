import React, { useState } from "react";

function ShoppingCart() {
  // Product list (static)
  const products = [
    { id: 1, name: "React T-Shirt", price: 25 },
    { id: 2, name: "Angular Hoodie", price: 40 },
    { id: 3, name: "Vue Cap", price: 15 }
  ];

  // Cart state (LIFTED STATE)
  const [cart, setCart] = useState([]);

  // Add to Cart
  const addToCart = (product) => {
    const existing = cart.find(item => item.id === product.id);

    if (existing) {
      // update quantity
      setCart(
        cart.map(item =>
          item.id === product.id
            ? { ...item, quantity: item.quantity + 1 }
            : item
        )
      );
    } else {
      // add new item
      setCart([...cart, { ...product, quantity: 1 }]);
    }
  };

  // Increase quantity
  const increaseQty = (id) => {
    setCart(
      cart.map(item =>
        item.id === id
          ? { ...item, quantity: item.quantity + 1 }
          : item
      )
    );
  };

  // Decrease quantity
  const decreaseQty = (id) => {
    setCart(
      cart
        .map(item =>
          item.id === id
            ? { ...item, quantity: item.quantity - 1 }
            : item
        )
        .filter(item => item.quantity > 0) // remove if 0
    );
  };

  // Remove item
  const removeItem = (id) => {
    setCart(cart.filter(item => item.id !== id));
  };

  // Total Price (Derived State)
  const total = cart.reduce(
    (sum, item) => sum + item.price * item.quantity,
    0
  );

  return (
    <div style={container}>

      <h2>🛍 Shopping Cart</h2>

      {/* PRODUCT LIST */}
      <div style={section}>
        <h3>Products</h3>

        {products.map(product => (
          <div key={product.id} style={card}>
            <span>
              {product.name} - ${product.price}
            </span>

            <button onClick={() => addToCart(product)}>
              Add
            </button>
          </div>
        ))}
      </div>

      {/* CART */}
      <div style={section}>
        <h3>Cart</h3>

        {cart.length === 0 && <p>Cart is empty</p>}

        {cart.map(item => (
          <div key={item.id} style={card}>
            
            <span>
              {item.name} x {item.quantity} = $
              {item.price * item.quantity}
            </span>

            <div>
              <button onClick={() => increaseQty(item.id)}>+</button>
              <button onClick={() => decreaseQty(item.id)}>-</button>
              <button onClick={() => removeItem(item.id)}>❌</button>
            </div>

          </div>
        ))}

        <h3>Total: ${total}</h3>
      </div>

    </div>
  );
}

/* Styles */
const container = {
  maxWidth: "600px",
  margin: "40px auto",
  fontFamily: "Arial"
};

const section = {
  marginBottom: "30px"
};

const card = {
  display: "flex",
  justifyContent: "space-between",
  padding: "10px",
  border: "1px solid #ccc",
  marginTop: "10px",
  borderRadius: "6px"
};

export default ShoppingCart;
