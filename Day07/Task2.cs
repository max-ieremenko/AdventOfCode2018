using System;
using System.Collections.Generic;
using System.Linq;

namespace Day07
{
    public static class Task2
    {
        public static int Solve(IEnumerable<string> input, int stepDuration, int workersCount)
        {
            var steps = Parser.Parse(input);
            for (var i = 0; i < steps.Count; i++)
            {
                steps[i].Duration = stepDuration + i + 1;
            }

            var result = 0;
            var activeSteps = new List<Step>(workersCount);
            while (steps.Count > 0)
            {
                UploadWorkers(steps, activeSteps, workersCount);
                activeSteps.Sort((x, y) => x.Duration.CompareTo(y.Duration));

                if (activeSteps.Count == 0)
                {
                    throw new InvalidOperationException();
                }

                var spent = activeSteps[0].Duration;
                result += spent;

                for (var i = 0; i < activeSteps.Count; i++)
                {
                    var step = activeSteps[i];
                    step.Duration -= spent;
                    if (step.Duration == 0)
                    {
                        CompleteStep(steps, step.Name);
                        activeSteps.RemoveAt(i);
                        i--;
                    }
                }
            }

            if (activeSteps.Count > 0)
            {
                result += activeSteps.Last().Duration;
            }

            return result;
        }

        private static void CompleteStep(IList<Step> steps, string stepName)
        {
            foreach (var step in steps)
            {
                step.DependsOn.Remove(stepName);
            }
        }

        private static void UploadWorkers(IList<Step> steps, IList<Step> activeSteps, int workersCount)
        {
            for (var i = activeSteps.Count; i < workersCount; i++)
            {
                var next = GetNext(steps);
                if (next == null)
                {
                    return;
                }

                activeSteps.Add(next);
            }
        }

        private static Step GetNext(IList<Step> steps)
        {
            for (var i = 0; i < steps.Count; i++)
            {
                var step = steps[i];
                if (step.DependsOn.Count == 0)
                {
                    steps.RemoveAt(i);
                    return step;
                }
            }

            return null;
        }
    }
}
