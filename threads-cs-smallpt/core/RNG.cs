using System;
using System.Threading;

namespace cs_smallpt {

    public class RNG {

		protected ThreadLocal< Random > rnd = new ThreadLocal< Random >(
			() => new Random(Thread.CurrentThread.ManagedThreadId));

        public double UniformFloat() {
            return this.rnd.Value.NextDouble();
        }
    }
}
