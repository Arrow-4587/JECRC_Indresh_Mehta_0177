import React, { useState } from "react";

function TodoApp() {
  const [task, setTask] = useState("");
  const [todos, setTodos] = useState([]);

  // Add Task
  const addTask = () => {
    if (task.trim() === "") return;

    const newTodo = {
      id: Date.now(),
      text: task,
      completed: false
    };

    setTodos([...todos, newTodo]); // immutable update
    setTask("");
  };

  // Delete Task
  const deleteTask = (id) => {
    setTodos(todos.filter(todo => todo.id !== id));
  };

  // Toggle Complete
  const toggleComplete = (id) => {
    setTodos(
      todos.map(todo =>
        todo.id === id
          ? { ...todo, completed: !todo.completed }
          : todo
      )
    );
  };

  return (
    <div style={containerStyle}>
      <h2>Todo List</h2>

      {/* Input */}
      <div>
        <input
          type="text"
          placeholder="Enter Task"
          value={task}
          onChange={(e) => setTask(e.target.value)}
          style={inputStyle}
        />
        <button onClick={addTask} style={buttonStyle}>
          Add
        </button>
      </div>

      {/* List */}
      <ul style={{ listStyle: "none", padding: 0 }}>
        {todos.map((todo) => (
          <li key={todo.id} style={todoStyle}>
            
            {/* Checkbox */}
            <input
              type="checkbox"
              checked={todo.completed}
              onChange={() => toggleComplete(todo.id)}
            />

            {/* Text */}
            <span
              style={{
                marginLeft: "10px",
                textDecoration: todo.completed ? "line-through" : "none"
              }}
            >
              {todo.text}
            </span>

            {/* Delete */}
            <button
              onClick={() => deleteTask(todo.id)}
              style={deleteStyle}
            >
              ❌
            </button>

          </li>
        ))}
      </ul>
    </div>
  );
}

/* Styles */
const containerStyle = {
  width: "400px",
  margin: "50px auto",
  textAlign: "center",
  fontFamily: "Arial"
};

const inputStyle = {
  padding: "10px",
  width: "200px",
  marginRight: "10px"
};

const buttonStyle = {
  padding: "10px",
  cursor: "pointer"
};

const todoStyle = {
  display: "flex",
  justifyContent: "space-between",
  alignItems: "center",
  marginTop: "10px",
  padding: "10px",
  border: "1px solid #ccc",
  borderRadius: "6px"
};

const deleteStyle = {
  background: "red",
  color: "white",
  border: "none",
  cursor: "pointer",
  padding: "5px 10px",
  borderRadius: "4px"
};

export default TodoApp;
