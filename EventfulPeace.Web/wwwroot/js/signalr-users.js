const usersConnection = new signalR.HubConnectionBuilder()
    .withUrl("/usersHub")
    .build();

usersConnection.on("ReceiveUsers", (users) => updateUserTable(users));
usersConnection.on("UsersChanged", () => fetchUsers());

usersConnection.start().catch(err => console.error(err));

const fetchUsers = () => {
    usersConnection.invoke("GetUsers", 1, 10).catch(err => console.error(err))
};

const updateUserTable = (users) => {
    const tableBody = document.getElementById("usersTableBody");
    tableBody.innerHTML = "";

    users.items.forEach(user => {
        const row = `<tr>
                <td>${user.name}</td>
                <td>${user.email}</td>
                <td>${user.role}</td>
            </tr>`;
        tableBody.innerHTML += row;
    });
}