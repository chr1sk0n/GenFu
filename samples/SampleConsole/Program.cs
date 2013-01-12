﻿using Angela.Core;
using System;
using System.Collections.Generic;
using System.Text;
using SampleConsole.Models;

namespace SampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Angie does whatever you tell her to.");
            sb.AppendLine("==================================================");
            sb.AppendLine("  1) Post me some blogs");
            sb.AppendLine("  2) Write some peeps out");
            sb.AppendLine("  3) Please address me");
            sb.AppendLine("  4) I'd listen to that");
            sb.AppendLine("  5) A New Trend in Music");
            sb.AppendLine();
            sb.AppendLine("  x to exit");
            sb.AppendLine();

            var instructions = sb.ToString();

            string input = string.Empty;
            while (input.ToLower() != "x")
            {
                Console.WriteLine(instructions);
                input = Console.ReadKey().Key.ToString().ToLower();
                switch (input)
                {
                    case "d1":
                        Console.WriteLine();
                        Console.WriteLine();
                        PostMeSomeBlogs();
                        Console.WriteLine();
                        break;
                    case "d2":
                        Console.WriteLine();
                        Console.WriteLine();
                        WriteSomePeepsOut();
                        Console.WriteLine();
                        break;
                    case "d3":
                        Console.WriteLine();
                        Console.WriteLine();
                        PleaseAddressMe();
                        Console.WriteLine();
                        break;
                    case "d4":
                        Console.WriteLine();
                        Console.WriteLine();
                        MyNewFavoriteMusicGenre();
                        Console.WriteLine();
                        break;
                    case "d5":
                        Console.WriteLine();
                        Console.WriteLine();
                        ANewTrendInMusic();
                        Console.WriteLine();
                        break;
                    case "x":
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Aw. So close. Try again.");
                        Console.WriteLine();
                        break;
                }
            }
        }

        private static void ANewTrendInMusic()
        {
            var artists = Angie.Configure<Artist>()
                .Fill(a => a.Name).AsMusicArtistName()
                .MakeList<Artist>();

            var genres = Angie.Configure<Genre>()
                .Fill(g => g.Description).AsMusicGenreDescription()
                .Fill(g => g.Name).AsMusicGenreName()
                .MakeList<Genre>();

            var album = Angie
                .Configure<Album>()
                .Fill(a => a.Price).WithinRange(7, 10)
                .Make<Album>();
            Console.WriteLine(album.ToString());
        }

        private static void MyNewFavoriteMusicGenre()
        {
            Console.WriteLine(Jen.Music.Genre.Name());
            Console.WriteLine("------------------------------");
            Console.WriteLine(Jen.Music.Genre.Description());
        }

        private static void PostMeSomeBlogs()
        {
            Angie.Default()
                .ListCount(3);

            var blogposts = Angie
                .Configure<BlogPost>()   
                .Fill(d => d.CreateDate).AsPastDate()
                .Fill(b => b.Comments, delegate
                    {
                        return Angie
                            .Set<BlogComment>()
                            .Fill(d => d.CommentDate).AsPastDate()
                            .MakeList<BlogComment>();
                    })
                .MakeList<BlogPost>();

            foreach (var post in blogposts)
            {
                Console.WriteLine(post.Title);
            }
        }

        private static void WriteSomePeepsOut()
        {
            Angie.Default()
                .ListCount(3);

            var people = Angie
                .Configure()
                .MakeList<Person>();

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }

        private static void PleaseAddressMe()
        {
            Angie.Default()
                .ListCount(3);

            var addresses = Angie
                .Configure()
                .MakeList<Location>();

            foreach (var location in addresses)
            {
                Console.WriteLine(location);
            }
        }
    }








}