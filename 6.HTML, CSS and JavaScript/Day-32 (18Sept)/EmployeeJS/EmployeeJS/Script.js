// Employee data array to store employees
let employees = JSON.parse(localStorage.getItem("employees")) || [];

// Function to add employee data from the form
function addEmployee(employee) {
    employees.push(employee);
    localStorage.setItem("employees", JSON.stringify(employees));
    window.location.href = "employee-list.html";
}

// Handle form submission for employee creation
document.getElementById("employeeForm")?.addEventListener("submit", function (event) {
    event.preventDefault();

    // Validate form data
    const firstName = document.getElementById("firstName").value;
    const middleName = document.getElementById("middleName").value;
    const lastName = document.getElementById("lastName").value;
    const email = document.getElementById("email").value;
    const age = document.getElementById("age").value;
    const address = document.getElementById("address").value;
    const profilePicture = document.getElementById("profilePicture").files[0]?.name || "No Image";

    if (firstName === "" || lastName === "" || email === "" || age === "" || address === "") {
        alert("Please fill out all required fields.");
        return;
    }

    const employee = {
        id: employees.length + 1,
        name: `${firstName} ${middleName} ${lastName}`,
        email: email,
        age: age,
        address: address,
        profilePicture: profilePicture,
    };

    addEmployee(employee);
});

// Function to display employees on the employee list page
function displayEmployees() {
    const employeeTableBody = document.getElementById("employeeTableBody");
    if (employeeTableBody) {
        employeeTableBody.innerHTML = "";
        employees.forEach((employee, index) => {
            const row = `<tr>
                            <td>${index + 1}</td>
                            <td>${employee.name}</td>
                            <td>${employee.email}</td>
                            <td>
                                <a href="#" class="btn btn-success" onclick="viewEmployee(${index})">View</a>
                                <a href="#" class="btn btn-primary" onclick="editEmployee(${index})">Edit</a>
                                <a href="#" class="btn btn-danger" onclick="deleteEmployee(${index})">Delete</a>
                            </td>
                        </tr>`;
            employeeTableBody.innerHTML += row;
        });
    }
}

// Function to delete an employee
function deleteEmployee(index) {
    employees.splice(index, 1);
    localStorage.setItem("employees", JSON.stringify(employees));
    displayEmployees();
}

// Function to view an employee (this will open a new page in the future)
function viewEmployee(index) {
    alert(`View details of ${employees[index].name}`);
}

// Function to edit an employee (this will open a new page in the future)
function editEmployee(index) {
    alert(`Edit details of ${employees[index].name}`);
}

// Call the function to display employees if we are on the employee list page
displayEmployees();





function previewImage(event) {
    const reader = new FileReader();
    reader.onload = function () {
        const output = document.getElementById('profilePreview');
        output.src = reader.result; // Set the source to the uploaded image
    };
    reader.readAsDataURL(event.target.files[0]);
}

const form = document.getElementById("employeeForm");

form.addEventListener("submit", function (event) {
    event.preventDefault();

    let hasError = false;
    const fields = form.querySelectorAll(".form-control");
    fields.forEach(field => field.classList.remove("is-invalid"));
    const genderFeedback = document.getElementById("genderFeedback");
    genderFeedback.style.display = "none";

    if (!form.gender.value) {
        hasError = true;
        genderFeedback.style.display = "block";
    }

    if (hasError) {
        return;
    }

    const employee = {
        firstName: document.getElementById("firstName").value,
        middleName: document.getElementById("middleName").value,
        lastName: document.getElementById("lastName").value,
        email: document.getElementById("email").value,
        age: document.getElementById("age").value,
        address: document.getElementById("address").value,
        gender: form.gender.value,
        experience: document.getElementById("experience").value,
        phone: document.getElementById("phone").value,
        country: document.getElementById("country").value,
        dob: document.getElementById("dob").value,
        profilePicture: document.getElementById("profileImage").files[0]?.name || "No Image",
    };

    // Save employee to local storage (you can adapt this part as needed)
    let employees = JSON.parse(localStorage.getItem("employees")) || [];
    employees.push(employee);
    localStorage.setItem("employees", JSON.stringify(employees));

    alert("Employee added successfully!");
    window.location.href = "employee-list.html";
});