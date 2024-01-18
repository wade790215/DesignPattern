using System;
using System.Threading.Tasks;
using System.Threading;

namespace DesignPattern
{
    internal class StatePattern
    {
        internal void Main()
        {
            //StateMachine stateMachine = new StateMachine(new PatrolState());

            //bool exitRequested = false;

            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        string input = Console.ReadLine();
            //        if (input.ToLower() == "exit")
            //        {
            //            exitRequested = true;
            //            break;
            //        }
            //    }
            //});

            //while (!exitRequested)
            //{
            //    float deltaTime = 1f;
            //    stateMachine.Update(deltaTime);
            //    Thread.Sleep(1000);
            //}

            //stateMachine.ExitCurrentState();

            Document document = new Document(new Draft());
            document.ChangeState(new Reviewing());
            document.ChangeState(new Approved());
            document.ChangeState(new Rejected());
            Console.ReadLine(); 
        }

        #region Pratice1
        public class StateMachine
        {
            public StateBase CurrentState { get; private set; }

            private float elapsedTime = 0f;

            public StateMachine(StateBase stateBase)
            {
                ChangeState(stateBase);
            }

            public void ChangeState(StateBase newState)
            {
                if (CurrentState != null)
                {
                    CurrentState.ExitState();
                }
                CurrentState = newState;
                CurrentState.EnterState();
            }

            public void Update(float deltaTime)
            {
                elapsedTime += deltaTime;

                if (elapsedTime > 5f && CurrentState is PatrolState)
                {
                    ChangeState(new ChaseState());
                }
                else if (elapsedTime > 10f && CurrentState is ChaseState)
                {
                    ChangeState(new AttackState());
                }
                else if (elapsedTime > 15f && CurrentState is AttackState)
                {
                    ChangeState(new PatrolState());
                    elapsedTime = 0f;
                }

                CurrentState.Update();
            }

            public void ExitCurrentState()
            {
                if (CurrentState != null)
                {
                    CurrentState.ExitState();
                }
            }
        }

        public abstract class StateBase
        {
            public abstract void EnterState();

            public abstract void Update();

            public abstract void ExitState();
        }

        public class AttackState : StateBase
        {
            public override void EnterState()
            {
                Console.WriteLine($"Enter {GetType().Name} State");
            }

            public override void ExitState()
            {
                Console.WriteLine($"Exite {GetType().Name} State");
            }

            public override void Update()
            {
                Console.WriteLine("Attacking");
            }
        }

        public class ChaseState : StateBase
        {
            public override void EnterState()
            {
                Console.WriteLine($"Enter {GetType().Name} State");
            }

            public override void ExitState()
            {
                Console.WriteLine($"Exite {GetType().Name} State");
            }

            public override void Update()
            {
                Console.WriteLine("Chasing");
            }
        }

        public class PatrolState : StateBase
        {
            public override void EnterState()
            {
                Console.WriteLine($"Enter {GetType().Name} State");
            }
            public override void ExitState()
            {
                Console.WriteLine($"Exite {GetType().Name} State");
            }
            public override void Update()
            {
                Console.WriteLine("Patrolling");
            }
        }
        #endregion

        #region Pratice2

        public class Document
        {
            private IDocumentState currentState;

            public Document(IDocumentState documentState)
            {
                currentState = documentState;   
                documentState.OnEnterState();
            }

            public void ChangeState(IDocumentState documentState)
            {
                currentState.OnExitState();
                currentState = documentState;
                currentState.OnEnterState();
            }
        }

        public interface IDocumentState
        {
            void OnEnterState();
            void OnExitState();
        }

        public class Draft : IDocumentState
        {
            public void OnEnterState()
            {
                Console.WriteLine("Draft_Enter");
            }

            public void OnExitState()
            {
                Console.WriteLine("Draft_Exit");
            }
        }

        public class Reviewing : IDocumentState
        {
            public void OnEnterState()
            {
                Console.WriteLine("Reviewing_Enter");
            }

            public void OnExitState()
            {
                Console.WriteLine("Reviewing_Exit");
            }
        }

        public class Approved : IDocumentState
        {
            public void OnEnterState()
            {
                Console.WriteLine("Approved_Enter");
            }

            public void OnExitState()
            {
                Console.WriteLine("Approved_Exit");
            }
        }

        public class Rejected : IDocumentState
        {
            public void OnEnterState()
            {
                Console.WriteLine("Rejected_Enter");
            }

            public void OnExitState()
            {
                Console.WriteLine("Rejected_Exit");
            }
        }

        #endregion
    }
}