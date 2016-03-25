using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Utilities.Collection
{
    public class BloomFilter<T>
    {
        #region Fields

        private BitArray _bitArray;

        /// <summary>
        /// 数据量
        /// </summary>
        private int _dataSize;

        /// <summary>
        /// 假阳性概率
        /// </summary>
        private float _falsePositiveRate;

        /// <summary>
        /// 空间大小
        /// </summary>
        private int _spaceSize;

        private int _numberOfHashes;

        #endregion


        #region Constructors

        /// <summary>
        /// 自动计算最佳空间和Hash函数个数
        /// </summary>
        /// <param name="dataSize"></param>
        /// <param name="falsePositiveRate"></param>
        public BloomFilter(int dataSize, float falsePositiveRate)
        {
            _dataSize = dataSize;
            _falsePositiveRate = falsePositiveRate;
        }

        public BloomFilter(int dateSize, int spaceSize)
        {
            _bitArray = new BitArray(spaceSize);
        }

        public BloomFilter(int dateSize, int spaceSize, int numberOfHashes)
        {
            _numberOfHashes = numberOfHashes;
            _bitArray = new BitArray(spaceSize);
        }

        #endregion

        #region Properties

        public int DataSize => _dataSize;

        public float FalsePositiveRate => _falsePositiveRate;

        public int SpaceSize => _spaceSize;

        public int NumberOfHashes => _numberOfHashes;

        #endregion


        #region Method

        public void Void(T item)
        {
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsAny(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                if (Contains(item))
                    return true;
            }

            return false;
        }

        public bool ContainsAll(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                if (!Contains(item))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 假阳性概率
        /// </summary>
        /// <returns></returns>
        private double FalsePositiveProbability()
        {
            return Math.Pow((1 - Math.Exp(-_numberOfHashes * _dataSize / (double)_spaceSize)), _numberOfHashes);
        }

        private int Hash(T item)
        {
            return item.GetHashCode();
        }

        private int OptimalNumberOfHashes(int spaceSize, int dataSize)
        {
            return (int)Math.Ceiling((spaceSize / dataSize) * Math.Log(2.0));
        }

        #endregion


    }
}
