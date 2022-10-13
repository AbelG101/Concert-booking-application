# Concert Booking system

  

> This is our final project as part of the requirement of the course Windows Programming (CS223). It is a winform app that allows users to book a concert event of their choice, a user can only book 5 tickets for a concert event at a time, this policy is in effect to discourage unfair ticket-buying practices. It has a 2-level user category: one as an administrator with special privileges such as adding/editing/removing concert events, artists, and genres and another for a regular customer. All the data in this application is stored and handeled using SQL server.
  

## Built With

- C#
- SQL Server

  

### Technologies used

- .NET Framework
- ADO.NET
- Git, Github.

  
## Getting Started

To get a local copy up and running follow these simple example steps.


### Prerequisites

- You'll need to have:
   - A basic understanding of Git and GitHub.
   - SQL Server managment studio.


## Install

To get a local copy up and running you'll need to have [SQL Server managment studio](https://aka.ms/ssmsfullsetup) installed on your local machine.


### Setup 

After installing SQL Server managment studio please follow the next steps...
- Start by cloning this repo (if you haven't already...)
- Open SQL Server managment studio
- Goto View > Object Explorer
- Then right click on Databases folder, and select New Database...
- Give the new database a name of 'Concert' and click OK.
- Open the file InitialSetup.sql from the Database/ directory of where you cloned this repo and follow the next steps.
- Execute the CREATE TABLE commands in the following order:
   - 1st CREATE TABLE Venue, 2nd CREATE TABLE genre, 3rd CREATE TABLE Artist
   - 4th CREATE TABLE Customer, 5th CREATE TABLE Concert, 6th CREATE TABLE Ticket and finally CREATE TABLE customer_order
- After you've created the tables you can insert the values:
   - Select everything starting from the first INSERT INTO Customer statment to the last line and click on the execute button. 

### Usage

-- To clone this project use:
```bash

git clone https://github.com/AbelG101/Concert-booking-application.git

```

## Author

  

👤 **Abel Gebeyehu**

  

- GitHub: [@AbelG101](https://github.com/AbelG101)

- LinkedIn: [Abel Gebeyehu](https://www.linkedin.com/in/abel-gebeyehu-779743183/)

  
  

## 🤝 Contributing

  

Contributions, issues, and feature requests are welcome!

  

Feel free to check the [issues page](../../issues/).

  

## Show your support

  

Give a ⭐️ if you like this project!

  

## 📝 License

  

This project is [MIT](./MIT.md) licensed.
