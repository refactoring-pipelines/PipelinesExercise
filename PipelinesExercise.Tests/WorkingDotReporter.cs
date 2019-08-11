using System;
using System.Collections.Generic;
using ApprovalTests.Reporters;
using Refactoring.Pipelines.Approvals;

namespace Tests
{
    public class WorkingDotReporter : GenericDiffReporter
        {
            public static readonly WorkingDotReporter INSTANCE = new WorkingDotReporter();

            public WorkingDotReporter()
                : base(new DiffInfo(@"C:\Users\jbazuzi\AppData\Local\Programs\Microsoft VS Code\bin\code.cmd", "-r {0}", (Func<IEnumerable<string>>)(() => (IEnumerable<string>)new string[1]
                {
                    "dot"
                })))
            {
            }
        }
}