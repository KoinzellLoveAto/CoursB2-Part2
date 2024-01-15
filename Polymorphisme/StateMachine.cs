using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineNS
{
    public class StateMachine
    {
        private AState m_currentState;



        public void HandleRequestStateChangement(AState a_newState)
        {
            //Condition block changement state
            //if(condition) return;

            if (m_currentState != null)
            {
                m_currentState.OnRequestChangeState -= HandleRequestStateChangement;
            }

            m_currentState?.OnLeave();
            m_currentState = a_newState;

            m_currentState?.OnEnter();
            m_currentState.OnRequestChangeState += HandleRequestStateChangement;

        }


        public void ProcessUpdate()
        {
            m_currentState?.OnProcess();
        }
    }

    abstract public class AState
    {
        public Action<AState> OnRequestChangeState;
        abstract public void OnProcess();

        abstract public void OnEnter();

        abstract public void OnLeave();

    }

    public class WalkState : AState
    {
        int counter = 0;
        public override void OnEnter()
        {

            Console.WriteLine("Enter WalkState");
        }

        public override void OnLeave()
        {
            Console.WriteLine("Leave WalkState");

        }

        public override void OnProcess()
        {
            Console.WriteLine("Process WalkState");
            counter++;

            if (counter >= 10)
            {
                OnRequestChangeState?.Invoke(new FlyState());
            }

        }
    }

    public class FlyState : AState
    {
        public override void OnEnter()
        {
            Console.WriteLine("Enter FlyState");
        }

        public override void OnLeave()
        {
            Console.WriteLine("Leave FlyState");
        }

        public override void OnProcess()
        {
            Console.WriteLine("Process FlyState");

        }
    }


    public class SwimmingState : AState
    {
        int timePass = 0;
        public override void OnEnter()
        {
            throw new NotImplementedException();
        }

        public override void OnLeave()
        {
            throw new NotImplementedException();
        }

        public override void OnProcess()
        {
            timePass++;
            if (timePass >= 30)
            {
                OnRequestChangeState.Invoke(new WalkState());
            }

        }
    }
}
