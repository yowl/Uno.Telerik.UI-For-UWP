using System;
using System.Diagnostics;
using Telerik.Data.Core.Fields;

namespace Telerik.Data.Core
{
    internal class DelegateMemberAccess : IMemberAccess
    {
        public Func<object, object> Getter
        {
            get;
            set;
        }

        public object GetValue(object item)
        {
            Debug.Write("DelegateMemberctieldInfo Get Value");

            if (this.Getter == null)
            {
                return null;
            }

            return this.Getter(item);
        }

        public void SetValue(object item, object fieldValue)
        {
            throw new NotImplementedException();
        }
    }
}
