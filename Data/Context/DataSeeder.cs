using Domain.Entities;
using Domain.Enums;

namespace Data.Context
{
    public static class DataSeeder
    {
        public static List<Author> SeedAuthors()
        {
            return [
                new Author
                    {
                            FullName = "Emily Jane xx Brontë",
                            Email = "emily@london.com",
                            Biography= "English novelist and poet, best known for her novel 'Wuthering Heights'.",
                            Website = "emily.novels.uk"
                        },
                        new Author {
                            FullName = "Mia Mohamed xx Attallah",
                            Email = "mirna@gmail.edu.com"
                        },
                        new Author {
                            FullName= "Emily xx xx Jane",
                            Email= "emily0jane@yahoo.com",
                            Biography= "English novelist and poet, best known for her novel 'Pride and Prejudice'.",
                        },
                        new Author
                        {
                            FullName = "John Michael Smith Doe",
                            Email = "john.doe@example.com",
                            Website = "https://johndoe.com",
                            Biography = "Author of thrilling adventure novels."
                        },
                        new Author
                        {
                            FullName = "Alice Mary Brown Lee",
                            Email = "alice.lee@example.com",
                            Website = "https://alicelee.com",
                            Biography = "Writes poetic and historical fiction."
                        }
                    ];
        }
        public static List<Book> SeedBooks(List<Author> authors)
        {
            Random random = new Random();
            
            return [
                new Book
                {
                    Title = "Wuthering Heights",
                    Genre = Genre.ROMANCE,
                    Description = "A tale of passion and revenge set on the Yorkshire moors.",
                    AuthorId = authors[random.Next(authors.Count)].Id
                },
                new Book
                {
                    Title = "Pride and Prejudice",
                    Genre = Genre.ROMANCE,
                    Description = "A romantic novel that critiques the British landed gentry at the end of the 18th century.",
                    AuthorId = authors[random.Next(authors.Count)].Id
                },
                new Book
                {
                    Title = "The Great Adventure",
                    Genre = Genre.ADVENTURE,
                    Description = "An epic journey through uncharted territories.",
                    AuthorId = authors[random.Next(authors.Count)].Id
                },
                new Book
                {
                    Title = "The Poetry of Nature",
                    Genre = Genre.POETRY,
                    Description = "A collection of poems celebrating the beauty of the natural world.",
                    AuthorId = authors[random.Next(authors.Count)].Id
                },
                new Book
                {
                    Title = "The Mystery of the Lost Treasure",
                    Genre = Genre.MYSTERY,
                    Description = "A thrilling mystery novel about a treasure hunt.",
                    AuthorId = authors[random.Next(authors.Count)].Id
                },
                new Book
                {
                    Title = "Historical Tales",
                    Genre = Genre.HISTORY,
                    Description = "A collection of short stories set in various historical periods.",
                    AuthorId = authors[random.Next(authors.Count)].Id
                }
                ];
        }
    }
}
