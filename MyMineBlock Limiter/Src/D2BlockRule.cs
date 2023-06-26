 using NetLimiter.Service;

namespace NLMMB.Src
{
    internal class D2BlockRule
    {
        public string Name;
        private readonly NLClient _client;
        private readonly Filter _filt;
        private readonly Rule _rule;
        private readonly Filter _filtModel;
        private readonly Rule _ruleModel;

        public D2BlockRule(NLClient client, string appPath, string name, RuleDir ruleDir, ushort portStart = 0, ushort portEnd = 0)
        {
            Name = name;
            _client = client;

            _filtModel = new Filter(Name);
            _filtModel.Functions.Add(new FFAppIdEqual(new AppId(appPath)));
            _filtModel.Functions.Add(new FFRemotePortInRange(new PortRangeFilterValue(portStart, portEnd)));

            _ruleModel = new FwRule(ruleDir, FwAction.Block);
            _filt = _client.Filters.Find(x => x.Name == Name);

            if (!Exists())
            {
                _filt = _client.AddFilter(_filtModel);
                _rule = _client.AddRule(_filtModel.Id, _ruleModel);
            }
            else
            {
                _client.RemoveFilter(_filt);
                _client.RemoveRule(_ruleModel);
                _filt = _client.AddFilter(_filtModel);
                _rule = _client.AddRule(_filtModel.Id, _ruleModel);
            }

            _rule.IsEnabled = false;
            _client.UpdateRule(_rule);
        }

        public bool Exists()
        {
            return _filt != null;
        }
    }
}