﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_Log_Output
{
    public class MyProxy : RealProxy
    {
        private MarshalByRefObject _target;

        public MyProxy(MarshalByRefObject target, Type t) : base(t)
        {
            this._target = target;
        }

        public override IMessage Invoke(IMessage msg)
        {
            IMethodCallMessage call = (IMethodCallMessage)msg;
            IMethodReturnMessage res;
            IConstructionCallMessage ctor = call as IConstructionCallMessage;

            if (ctor != null)
            {
                //以下、コンストラクタを実行する処理

                RealProxy rp = RemotingServices.GetRealProxy(this._target);
                res = rp.InitializeServerObject(ctor);
                MarshalByRefObject tp = this.GetTransparentProxy() as MarshalByRefObject;
                res = EnterpriseServicesHelper.CreateConstructionReturnMessage(ctor, tp);
            }
            else
            {
                //以下、コンストラクタ以外のメソッドを実行する処理

                //メソッド前処理
                Console.WriteLine("[{0}]{1} : 実行開始",
                    DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), call.MethodName);

                //メソッド実行
                res = RemotingServices.ExecuteMessage(this._target, call);

                //メソッド後処理
                Console.WriteLine("[{0}]{1} : 実行終了",
                    DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), call.MethodName);

            }

            return res;
        }
    }
}
