const api = "https://localhost:5001/api";

function register(){

const data = {

username: document.getElementById("rusername").value,
password: document.getElementById("rpassword").value,
role: document.getElementById("role").value

};

fetch(api + "/auth/register",{

method:"POST",

headers:{
"Content-Type":"application/json"
},

body:JSON.stringify(data)

})

.then(res=>res.text())
.then(data=>{
alert(data);
window.location="login.html";
});

}


function login(){

const data = {

username: document.getElementById("username").value,
password: document.getElementById("password").value

};

fetch(api+"/auth/login",{

method:"POST",

headers:{
"Content-Type":"application/json"
},

body:JSON.stringify(data)

})

.then(res=>res.json())
.then(data=>{

localStorage.setItem("token",data.token);
localStorage.setItem("role",data.role);
localStorage.setItem("userId",data.userId);

alert("Login Successful");

window.location="dashboard.html";

});

}


function logout(){

localStorage.clear();

window.location="login.html";

}


function applyLeave(){

const data = {

employeeId: localStorage.getItem("userId"),

leaveType: document.getElementById("leaveType").value,

startDate: document.getElementById("startDate").value,

endDate: document.getElementById("endDate").value,

reason: document.getElementById("reason").value

};

fetch(api+"/leave/apply",{

method:"POST",

headers:{
"Content-Type":"application/json",
"Authorization":"Bearer "+localStorage.getItem("token")
},

body:JSON.stringify(data)

})

.then(res=>res.text())
.then(data=>alert(data));

}


function loadLeaves(){

fetch(api+"/leave/all",{

headers:{
"Authorization":"Bearer "+localStorage.getItem("token")
}

})

.then(res=>res.json())
.then(data=>{

let rows="";

data.forEach(l=>{

rows+=`

<tr>

<td>${l.id}</td>
<td>${l.employeeId}</td>
<td>${l.leaveType}</td>
<td>${l.startDate}</td>
<td>${l.endDate}</td>
<td>${l.reason}</td>
<td>${l.status}</td>

<td>

<button onclick="approve(${l.id})">Approve</button>

<button onclick="reject(${l.id})">Reject</button>

</td>

</tr>

`;

});

document.getElementById("leaveTable").innerHTML=rows;

});

}


function approve(id){

fetch(api+"/leave/approve/"+id,{

method:"PUT",

headers:{
"Authorization":"Bearer "+localStorage.getItem("token")
}

})
.then(()=>loadLeaves());

}


function reject(id){

fetch(api+"/leave/reject/"+id,{

method:"PUT",

headers:{
"Authorization":"Bearer "+localStorage.getItem("token")
}

})
.then(()=>loadLeaves());

}