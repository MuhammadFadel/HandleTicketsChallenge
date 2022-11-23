# HandleTicketsChallenge
Implement a ticket system.

System-Flow and Cycles:
	1- Create a ticket with the following properties:
		Id, creation date and time, and phone number, (governorate, city, district) are drop-down lists
		making them static no need for a database only the ticket entity.
	2- List those tickets in a list after creating this list should be paginated as 5 records per page.
	3- Each ticket has a handle button which changes the status to handle if clicked.
	4- Tickets will be automatically marked as handled if it was created within 60 minutes.
	5- Each ticket will have a color yellow if it was created 15 minutes ago
		Green if it was created 30 minutes ago
		Blue if it was created 45 minutes ago
		Red if it was created 60 minutes ago