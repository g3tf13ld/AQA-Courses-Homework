﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homework3.Interfaces;

namespace Homework3.Models
{
    public class СandidateReportGenerator : IReportGenerator
    {
        private List<Candidate> Candidates { get; set; }

        public СandidateReportGenerator(List<Candidate> candidates)
        {
            Candidates = candidates;
        }
        private void Sort()
        {
            var orderedCandidates = from candidate in Candidates
                                       orderby candidate.Job.Title, candidate.Job.Salary
                                       select candidate;
            Candidates = orderedCandidates.ToList();
        }

        public void Report()
        {
            Sort();
            // The longest Title, FullName and Salary in the Candidates List.
            var symbolCounter1 = 9;
            var symbolCounter2 = 20;
            var symbolCounter3 = 6;
            
            // The longest Title, FullName and Salary value finding.
            foreach (var candidate in Candidates)
            {
                if (candidate.Job.Title.Length > symbolCounter1)
                {
                    symbolCounter1 = candidate.Job.Title.Length;
                }
                if (candidate.FullName.Length > symbolCounter2)
                {
                    symbolCounter2 = candidate.FullName.Length;
                }
                if (candidate.Job.Salary.ToString().Length > symbolCounter2)
                {
                    symbolCounter3 = candidate.Job.Salary.ToString().Length;
                }
            }

            // Report printing start.
            // Report table header.
            Console.WriteLine("Candidates report");
            var stringBuilder = new StringBuilder();
            Console.WriteLine(stringBuilder.Insert(0, "_", 58 + symbolCounter1 + symbolCounter2).ToString());
            stringBuilder.Clear();
            stringBuilder.Append("|                  Id                  ||");
            
            if (symbolCounter1 <= "Job Title".Length)
            {
                stringBuilder.Append(" Job Title ||");
            }
            else
            {
                stringBuilder.Append(" Job Title ")
                    .Insert(stringBuilder.Length, " ", symbolCounter1 - 9)
                    .Append("||");
            }
            if (symbolCounter2 <= "Candidates Full Name".Length)
            {
                stringBuilder.Append(" Candidates Full Name ||");
            }
            else
            {
                stringBuilder.Append(" Candidates Full Name ")
                    .Insert(stringBuilder.Length, " ", symbolCounter2 - 20)
                    .Append("||");
            }
            stringBuilder.Append(" Salary |");
            Console.WriteLine(stringBuilder.ToString());
            
            // Report body.
            foreach (var candidate in Candidates)
            {
                stringBuilder.Clear();
                stringBuilder.Append("| " + candidate.Id + " || ");
                
                stringBuilder.Append(candidate.Job.Title)
                    .Insert(stringBuilder.Length, " ",  symbolCounter1 - candidate.Job.Title.Length)
                    .Append(" || ");
                
                stringBuilder.Append(candidate.FullName)
                    .Insert(stringBuilder.Length, " ", symbolCounter2 - candidate.FullName.Length)
                    .Append(" || "); 
                
                stringBuilder.Append(candidate.Job.Salary)
                    .Insert(stringBuilder.Length, " ", symbolCounter3 - candidate.Job.Salary.ToString().Length)
                    .Append(" |");
                
                Console.WriteLine(stringBuilder.ToString());
            }

            Console.WriteLine(stringBuilder.Clear().Insert(0, "-", 58 + symbolCounter1 + symbolCounter2).ToString());
        }
    }
}