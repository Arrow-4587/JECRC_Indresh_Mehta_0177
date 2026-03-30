import React, {useState} from "react";

function Counter(){
    const [count, setCount] = React.useState(0);
    const [step,setStep] = React.useState(1);
    const[lastAction, setLastAction] = React.useState("None");
    
    function increment(){
        setCount(count + step);
        setLastAction("Incremented by " + step);
    }
    function decrement(){
        setCount(count - step);
        setLastAction("Decremented by " + step);
    }
    const reset = () => {
        setCount(0);
        setStep(1);
        setLastAction("Reset to 0");
    }
    return(
      <div style={{ padding: '20px', textAlign: 'center'}}>
        {/* Display Current state */}
        <div style={{fontSize: '48px', margin: '20px'}}>
          <h1>Counter: {count}</h1>
        </div>
             {/*Step input*/ }
             <div style = {{margiBottom: '20px'}}>
                <label> Step: 
                    <input 
                     type = "number" value = {step} onChange = {(e) => setStep(Number(e.target.value))}
                     style = {{marginLeft: '10px', width: '60px'}}
                    />
                    </label> </div>
        {/* Action Buttons */}
        <div style={{margin: '20px'}}>
          <button onClick={increment} style = {buttonStyle}>Increment</button>
          <button onClick={decrement} style={buttonStyle}>Decrement</button>
          <button onClick={reset} style = {buttonStyle}>Reset</button>
        </div>
        <div style={{ marginTop: "20px", fontSize: "18px", color: "#555" }}>
        <strong>Last Action:</strong> {lastAction}
      </div>

      </div>
    )
}

const buttonStyle = {
    padding: '10px 20px',
    fontSize: '16px',
    margin: '0 10px',
    cursor: 'pointer',
    backgroundColor: '#007bff',
    color: 'white',
    border: 'none',
    borderRadius: '6px',
}
export default Counter;