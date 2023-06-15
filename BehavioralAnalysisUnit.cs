using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVsAssignment
{
   public class BehavioralAnalysisUnit
    {
      
        string _agentFirst; 
        string _agentLast;
        string _education;
        string _specialty;


        public BehavioralAnalysisUnit() //Default constructor for loading into CSV 
        {

        }
        public BehavioralAnalysisUnit(string agentFirst, string agentLast, string education, string specialty)
        {
            
            _agentFirst = agentFirst;
            _agentLast = agentLast;
            _education = education;
            _specialty = specialty;
        }

        public string AgentFirst { get => _agentFirst; set => _agentFirst = value; }
        public string AgentLast { get => _agentLast; set => _agentLast = value; }
        public string Education { get => _education; set => _education = value; }
        public string Specialty { get => _specialty; set => _specialty = value; }
    }
}
