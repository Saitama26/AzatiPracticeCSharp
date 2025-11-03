namespace Day2Solution.Task3Polynomial
{
    public class Polynomial
    {
        private readonly double[] _coefficients;

        public Polynomial(params double[] coefficients)
        {
            if (coefficients == null || coefficients.Length == 0)
                throw new ArgumentException("Polynomial must have at least one coefficient.");

            _coefficients = new double[coefficients.Length];
            Array.Copy(coefficients, _coefficients, coefficients.Length);
        }

        public int GetDegree => _coefficients.Length - 1;
        private double this[int i] => i >= 0 && i < _coefficients.Length ? _coefficients[i] : 0;


        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            if (p1 is null) throw new ArgumentNullException(nameof(p1));
            if (p2 is null) throw new ArgumentNullException(nameof(p2));

            int MaxDegree = Math.Max(p1.GetDegree, p2.GetDegree);
            double[] coefficients = new double[MaxDegree + 1];

            for (int i = 0; i <= MaxDegree; i++)
                coefficients[i] = p1[i] + p2[i];

            return new Polynomial(coefficients);
        }

        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            if (p1 is null) throw new ArgumentNullException(nameof(p1));
            if (p2 is null) throw new ArgumentNullException(nameof(p2));

            int MaxDegree = Math.Max(p1.GetDegree, p2.GetDegree);
            double[] coefficients = new double[MaxDegree + 1];

            for (int i = 0; i <= MaxDegree; i++)
                coefficients[i] = p1[i] - p2[i];

            return new Polynomial(coefficients);
        }

        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            if (p1 is null) throw new ArgumentNullException(nameof(p1));
            if (p2 is null) throw new ArgumentNullException(nameof(p2));
            
            double[] coefficients = new double[p1.GetDegree + p2.GetDegree + 1];

            for (int i = 0; i <= p1.GetDegree; i++)
            {
                for (int j = 0; j <= p2.GetDegree; j++)
                {
                    coefficients[i + j] += p1[i] * p2[j];
                }
            }

            return new Polynomial(coefficients);
        }

        public static bool operator ==(Polynomial p1, Polynomial p2)
        {
            if (ReferenceEquals(p1, p2)) return true;
            if (p1 is null || p2 is null) return false;

            if (p1.GetDegree != p2.GetDegree) return false;

            for (int i = 0; i <= p1.GetDegree; i++)
            {
                if (p1[i] != p2[i])
                    return false;
            }
            return true;
        }

        public static bool operator !=(Polynomial p1, Polynomial p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals (this, obj)) return true;
            if (obj == null || obj.GetType() != typeof(Polynomial)) return false;

            var other = obj as Polynomial;

            if (this._coefficients.Length != other.GetDegree) return false;

            for (int i = 0; i <= other.GetDegree; i++)
            {
                if (this[i] != other[i])
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            var rnd = new Random();
            int hash = 1;
            foreach (var c in _coefficients)
                hash = hash * rnd.Next(30, 100) + c.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            var terms = new List<string>();
            for (int i = _coefficients.Length - 1; i >= 0; i--)
            {
                double coeff = _coefficients[i];
                if (coeff == 0) continue;

                string term = i switch
                {
                    0 => $"{coeff}",
                    1 => $"{coeff}x",
                    _ => $"{coeff}x^{i}"
                };
                terms.Add(term);
            }
            return string.Join(" + ", terms);

        }

    }
}
