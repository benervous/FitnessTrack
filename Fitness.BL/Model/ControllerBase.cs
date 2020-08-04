using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Controller basement.
    /// </summary>
    public abstract class ControllerBase
    {
        /// <summary>
        /// File name.
        /// </summary>
        public string FileName;
        /// <summary>
        /// Save data.
        /// </summary>
        /// <param name="FileName">File name.</param>
        /// <param name="item">Object item to save.</param>
        protected void Save(string FileName, object item)
        {
            var formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
        /// <summary>
        /// Load serialized file.
        /// </summary>
        /// <typeparam name="T">Optional name of collection for users.</typeparam>
        /// <param name="FileName">File name.</param>
        /// <returns></returns>
        protected T Load<T>(string FileName) {
            var formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }
    }
}
