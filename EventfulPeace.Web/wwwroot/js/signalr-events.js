const eventsConnection = new signalR.HubConnectionBuilder()
    .withUrl("/eventsHub")
    .build();

eventsConnection.on("ReceiveEvents", (events) => updateEventTable(events));
eventsConnection.on("EventsChanged", () => fetchEvents());

eventsConnection.start().catch(err => console.error(err));

const fetchEvents = () => {
    eventsConnection.invoke("GetEvents", 1, 10).catch(err => console.error(err))
};

const updateEventTable = (events) => {
    const tableBody = document.getElementById("eventsTableBody");
    tableBody.innerHTML = "";

    events.items.forEach(event => {
        const row = `<tr>
                <td>${event.name}</td>
                <td>${event.location.name}</td>
                <td>${event.occursAt}</td>
            </tr>`;
        tableBody.innerHTML += row;
    });
}