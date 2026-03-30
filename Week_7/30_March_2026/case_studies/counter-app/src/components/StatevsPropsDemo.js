// import React, {useState} from "react";
// function DisplayCard({title, value, onCharge})
// {
// const [internalCount, setInternalCount] = useState(0);

// return (
//     <div style = {{border: '1px solid #ccc',
//         borderRadius: '8px', padding: '20px',
//         margin: '10px', width: '200px',
//         textAlign : 'center'}}>
//             <h3>{title}</h3>
//             <p>Props Value from Parent: {value}</p>
//             <button onClick={() => setInternalCount(internalCount +1)}>
//                 Upadte Inetrnal Count
//             </button>
//             <button onClick={() => onCharge(value +1)}>
//                 Update Parent Count
//             </button>
//     </div>
// )
// }

// function StatevsPropsDemo()
// {
//     const [parentCount, setParentCount] = useState(0);
//     const [parentStep, setParentState] = useState(1);
//     const [displayColor] = useState('lightbulb');

//     const handleParentCountChange = (newCount) => {
//         setParentColor (newCount) ;
//         setDisplyColor(newCount % 2 === 0 ? 'lightbulb' : 'lightcoral');
//     }
//     return (
//         <div style={{display: 'flex', justifyContent: 'center', padding: '20px'}}>
//       <p>Parent Count: {parentCount}</p>
//       <button onClick={() => setParentStep(parentStep + 1)} 
//       style={{marginLeft: '20px'}}>
//         Increase Step (Current: {parentStep})</button>
//       <button onClick={() => setDisplayColor
//         (displayColor === 'lightblue' ? 'lightcoral' : 'lightblue')} 
//         style={{marginLeft: '20px'}}>
//         Toggle Display Color</button>
//       <DisplayCard
//         title="Child Component 1 Counter Card" 
//         value={parentCount} 
//         onChange={handleParentCountChange} 
//         style={{backgroundColor: displayColor}}
//       />
//        <DisplayCard
//         title="Child Component 2 Counter Card" 
//         value={parentCount} 
//         onChange={handleParentCountChange} 
//         style={{backgroundColor: displayColor}}
//       />
//     </div>
//     )
// }

// export default StatevsPropsDemo;

import React, { useState } from "react";

// CHILD COMPONENT
function DisplayCard({ title, value, onChange, style }) {
  const [internalCount, setInternalCount] = useState(0);

  return (
    <div
      style={{
        border: "1px solid #ccc",
        borderRadius: "8px",
        padding: "20px",
        margin: "10px",
        width: "220px",
        textAlign: "center",
        ...style
      }}
    >
      <h3>{title}</h3>

      <p>Props Value from Parent: {value}</p>
      <p>Internal Count: {internalCount}</p>

      <button onClick={() => setInternalCount(internalCount + 1)}>
        Update Internal Count
      </button>

      <br /><br />

      <button onClick={() => onChange(value + 1)}>
        Update Parent Count
      </button>
    </div>
  );
}

// PARENT COMPONENT
function StatevsPropsDemo() {
  const [parentCount, setParentCount] = useState(0);
  const [parentStep, setParentStep] = useState(1);
  const [displayColor, setDisplayColor] = useState("lightblue");

  const handleParentCountChange = (newCount) => {
    setParentCount(newCount);

    // change color based on even/odd
    setDisplayColor(newCount % 2 === 0 ? "lightblue" : "lightcoral");
  };

  return (
    <div style={{ textAlign: "center", padding: "20px" }}>
      
      <h2>Parent Count: {parentCount}</h2>

      <button onClick={() => setParentStep(parentStep + 1)}>
        Increase Step (Current: {parentStep})
      </button>

      <button
        onClick={() =>
          setDisplayColor(
            displayColor === "lightblue" ? "lightcoral" : "lightblue"
          )
        }
        style={{ marginLeft: "10px" }}
      >
        Toggle Display Color
      </button>

      <div style={{ display: "flex", justifyContent: "center" }}>
        
        <DisplayCard
          title="Child Component 1"
          value={parentCount}
          onChange={handleParentCountChange}
          style={{ backgroundColor: displayColor }}
        />

        <DisplayCard
          title="Child Component 2"
          value={parentCount}
          onChange={handleParentCountChange}
          style={{ backgroundColor: displayColor }}
        />

      </div>
    </div>
  );
}

export default StatevsPropsDemo;
