Project Outline:

// Will need two users: librarians and patrons.

// Will need a Book model (table) with info like title, year published, genre, pages, etc.

// Will need an Authors model (table) with info for their name

// Will need a join table for Book and Author to create a many-to-many relationship.

//  Will need a one-to-many relationship between a book and copies (create a Copies model/table)

// Will need a checkouts table that joins Patron and Copies.

Changes:

// Allow patron to check out a book only if there is more than one copy.
    * add checkout date and due date property to checkout model
    * change checkout table to join patrons and books and design it to interact with copies.