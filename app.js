const express = require('express');
const bodyParser = require('body-parser');

const app = express();
app.use(bodyParser.json());

const books = [
  { id: 1, title: 'Book 1' },
  { id: 2, title: 'Book 2' },
  // ... initial data
];

// Routes for CRUD operations
app.get('/books', (req, res) => {
  res.json(books);
});

app.get('/books/:id', (req, res) => {
  const book = books.find(book => book.id === parseInt(req.params.id));
  if (!book) return res.status(404).send('Book not found');
  res.json(book);
});

app.post('/books', (req, res) => {
  const book = {
    id: books.length + 1,
    title: req.body.title
  };
  books.push(book);
  res.json(book);
});

app.put('/books/:id', (req, res) => {
  const book = books.find(book => book.id === parseInt(req.params.id));
  if (!book) return res.status(404).send('Book not found');

  book.title = req.body.title;
  res.json(book);
});

app.delete('/books/:id', (req, res) => {
  const bookIndex = books.findIndex(book => book.id === parseInt(req.params.id));
  if (bookIndex === -1) return res.status(404).send('Book not found');

  const deletedBook = books.splice(bookIndex, 1);
  res.json(deletedBook[0]);
});

const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});
