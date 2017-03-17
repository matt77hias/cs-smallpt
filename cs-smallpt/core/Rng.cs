using System;

namespace cs_smallpt {

    public class RNG {

        protected Random rnd;

        public RNG(int seed = 606418532) {
            Seed(seed);
        }

        public void Seed(int seed) {
            this.rnd = new Random(seed);
        }

        public double UniformFloat() {
            return this.rnd.NextDouble();
        }
    }
}
