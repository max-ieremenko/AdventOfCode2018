using System;
using System.Collections.Generic;
using System.Globalization;

namespace Day19
{
    internal static class OpCodeFactory
    {
        public static OpCodeBase CreateByName(string name)
        {
            var typeName = string.Format(CultureInfo.InvariantCulture, "{0}+OpCode{1}", typeof(OpCodeFactory).FullName, name);
            var type = typeof(OpCodeFactory).Assembly.GetType(typeName, true, true);

            return (OpCodeBase)Activator.CreateInstance(type);
        }

        public static IList<OpCodeBase> GetAllOpCodes()
        {
            return new OpCodeBase[]
            {
                new OpCodeAddr(),
                new OpCodeAddi(),

                new OpCodeMulr(),
                new OpCodeMuli(),

                new OpCodeBanr(),
                new OpCodeBani(),

                new OpCodeBorr(),
                new OpCodeBori(),

                new OpCodeSetr(),
                new OpCodeSeti(),

                new OpCodeGtir(),
                new OpCodeGtri(),
                new OpCodeGtrr(),

                new OpCodeEqir(),
                new OpCodeEqri(),
                new OpCodeEqrr(),
            };
        }

        private sealed class OpCodeAddr : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                context.Registers[C] = context.Registers[A] + context.Registers[B];
            }

            public override string ToString()
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "addr R{0}=R{1}+R{2}",
                    C,
                    A,
                    B);
            }
        }

        private sealed class OpCodeAddi : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                context.Registers[C] = context.Registers[A] + B;
            }

            public override string ToString()
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "addi R{0}=R{1}+{2}",
                    C,
                    A,
                    B);
            }
        }

        private sealed class OpCodeMulr : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                context.Registers[C] = context.Registers[A] * context.Registers[B];
            }

            public override string ToString()
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "mulr R{0}=R{1}*R{2}",
                    C,
                    A,
                    B);
            }
        }

        private sealed class OpCodeMuli : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                context.Registers[C] = context.Registers[A] * B;
            }

            public override string ToString()
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "mili R{0}=R{1}*{2}",
                    C,
                    A,
                    B);
            }
        }

        private sealed class OpCodeBanr : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                context.Registers[C] = context.Registers[A] & context.Registers[B];
            }

            public override string ToString()
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "banr R{0}=R{1}&R{2}",
                    C,
                    A,
                    B);
            }
        }

        private sealed class OpCodeBani : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                context.Registers[C] = context.Registers[A] & B;
            }

            public override string ToString()
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "bani R{0}=R{1}&{2}",
                    C,
                    A,
                    B);
            }
        }

        private sealed class OpCodeBorr : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                context.Registers[C] = context.Registers[A] | context.Registers[B];
            }

            public override string ToString()
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "borr R{0}=R{1}|R{2}",
                    C,
                    A,
                    B);
            }
        }

        private sealed class OpCodeBori : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                context.Registers[C] = context.Registers[A] | B;
            }

            public override string ToString()
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "bori R{0}=R{1}|{2}",
                    C,
                    A,
                    B);
            }
        }

        private sealed class OpCodeSetr : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                context.Registers[C] = context.Registers[A];
            }

            public override string ToString()
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "setr R{0}=R{1}",
                    C,
                    A);
            }
        }

        private sealed class OpCodeSeti : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                context.Registers[C] = A;
            }

            public override string ToString()
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "seti R{0}={1}",
                    C,
                    A);
            }
        }

        private sealed class OpCodeGtir : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                if (A > context.Registers[B])
                {
                    context.Registers[C] = 1;
                }
                else
                {
                    context.Registers[C] = 0;
                }
            }

            public override string ToString()
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "gtir R{0}=1, R{1}>R{2}",
                    C,
                    A,
                    B);
            }
        }

        private sealed class OpCodeGtri : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                if (context.Registers[A] > B)
                {
                    context.Registers[C] = 1;
                }
                else
                {
                    context.Registers[C] = 0;
                }
            }

            public override string ToString()
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "gtri R{0}=R{1}>{2} ? 1:0",
                    C,
                    A,
                    B);
            }
        }

        private sealed class OpCodeGtrr : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                if (context.Registers[A] > context.Registers[B])
                {
                    context.Registers[C] = 1;
                }
                else
                {
                    context.Registers[C] = 0;
                }
            }

            public override string ToString()
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "gtrr R{0}=R{1}>R{2} ? 1:0",
                    C,
                    A,
                    B);
            }
        }

        private sealed class OpCodeEqir : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                if (A == context.Registers[B])
                {
                    context.Registers[C] = 1;
                }
                else
                {
                    context.Registers[C] = 0;
                }
            }

            public override string ToString()
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "eqir R{0}={1}=R{2} ? 1:0",
                    C,
                    A,
                    B);
            }
        }

        private sealed class OpCodeEqri : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                if (context.Registers[A] == B)
                {
                    context.Registers[C] = 1;
                }
                else
                {
                    context.Registers[C] = 0;
                }
            }

            public override string ToString()
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "eqri R{0}=R{1}={2} ? 1:0",
                    C,
                    A,
                    B);
            }
        }

        private sealed class OpCodeEqrr : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                if (context.Registers[A] == context.Registers[B])
                {
                    context.Registers[C] = 1;
                }
                else
                {
                    context.Registers[C] = 0;
                }
            }

            public override string ToString()
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "eqrr R{0}=R{1}=R{2} ? 1:0",
                    C,
                    A,
                    B);
            }
        }
    }
}