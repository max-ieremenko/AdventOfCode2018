using System.Collections.Generic;

namespace Day16
{
    internal static class OpCodeFactory
    {
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
        }

        private sealed class OpCodeAddi : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                context.Registers[C] = context.Registers[A] + B;
            }
        }

        private sealed class OpCodeMulr : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                context.Registers[C] = context.Registers[A] * context.Registers[B];
            }
        }

        private sealed class OpCodeMuli : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                context.Registers[C] = context.Registers[A] * B;
            }
        }

        private sealed class OpCodeBanr : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                context.Registers[C] = context.Registers[A] & context.Registers[B];
            }
        }

        private sealed class OpCodeBani : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                context.Registers[C] = context.Registers[A] & B;
            }
        }

        private sealed class OpCodeBorr : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                context.Registers[C] = context.Registers[A] | context.Registers[B];
            }
        }

        private sealed class OpCodeBori : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                context.Registers[C] = context.Registers[A] | B;
            }
        }

        private sealed class OpCodeSetr : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                context.Registers[C] = context.Registers[A];
            }
        }

        private sealed class OpCodeSeti : OpCodeBase
        {
            public override void Invoke(OpCodeContext context)
            {
                context.Registers[C] = A;
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
        }
    }
}