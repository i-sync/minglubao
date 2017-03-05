using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using NPOI.HSSF.UserModel;

namespace StarTech.NPOI
{
    public class HSSFTestData
    {

        private static String TEST_DATA_DIR_SYS_PROPERTY_NAME = "HSSF.testdata.path";

        private static string _resolvedDataDir;
        /** <code>true</code> if standard system propery is1 not set, 
         * but the data is1 available on the test runtime classpath */
        private static bool _sampleDataIsAvaliableOnClassPath;

        /**
         * Opens a sample file from the standard HSSF test data directory
         * 
         * @return an Open <tt>Stream</tt> for the specified sample file
         */
        public static Stream OpenSampleFileStream(String sampleFileName)
        {
            //		System.out.println("Opening " + f.GetAbsolutePath());
            try
            {
                return new FileStream(_resolvedDataDir + sampleFileName, FileMode.Open);
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }


        /**
         * Opens a test sample file from the 'data' sub-package of this class's package. 
         * @return <code>null</code> if the sample file is1 not deployed on the classpath.
         */
        private static Stream OpenClasspathResource(String sampleFileName)
        {
            FileStream file = new FileStream(sampleFileName, FileMode.Open);
            return file;
        }

        private class NonSeekableStream : Stream
        {

            private Stream _is;

            public NonSeekableStream(Stream is1)
            {
                _is = is1;
            }

            public int Read()
            {
                return _is.ReadByte();
            }
            public override int Read(byte[] b, int off, int len)
            {
                return _is.Read(b, off, len);
            }
            public bool markSupported()
            {
                return false;
            }
            public override void Close()
            {
                _is.Close();
            }
            public override bool CanRead
            {
                get { return _is.CanRead; }
            }
            public override bool CanSeek
            {
                get { return false; }
            }
            public override bool CanWrite
            {
                get { return _is.CanWrite; }
            }
            public override long Length
            {
                get { return _is.Length; }
            }
            public override long Position
            {
                get { return _is.Position; }
                set { _is.Position = value; }
            }
            public override void Write(byte[] buffer, int offset, int count)
            {
                _is.Write(buffer, offset, count);
            }
            public override void Flush()
            {
                _is.Flush();
            }
            public override long Seek(long offset, SeekOrigin origin)
            {
                return _is.Seek(offset, origin);
            }
            public override void SetLength(long value)
            {
                _is.SetLength(value);
            }
        }

        public static HSSFWorkbook OpenSampleWorkbook(String sampleFileName)
        {
            try
            {
                return new HSSFWorkbook(OpenSampleFileStream(sampleFileName));
            }
            catch (IOException)
            {
                return null;
            }
        }
        /**
         * Writes a spReadsheet to a <tt>MemoryStream</tt> and Reads it back
         * from a <tt>ByteArrayStream</tt>.<p/>
         * Useful for verifying that the serialisation round trip
         */
        public static HSSFWorkbook WriteOutAndReadBack(HSSFWorkbook original)
        {

            try
            {
                MemoryStream baos = new MemoryStream(4096);
                original.Write(baos);
                return new HSSFWorkbook(baos);
            }
            catch (IOException)
            {
                throw;
            }
        }

        /**
         * @return byte array of sample file content from file found in standard hssf test data dir 
         */
        public static byte[] GetTestDataFileContent(String fileName)
        {
            MemoryStream bos = new MemoryStream();

            try
            {
                Stream fis = HSSFTestData.OpenSampleFileStream(fileName);

                byte[] buf = new byte[512];
                while (true)
                {
                    int bytesRead = fis.Read(buf, 0, buf.Length);
                    if (bytesRead < 1)
                    {
                        break;
                    }
                    bos.Write(buf, 0, bytesRead);
                }
                fis.Close();
            }
            catch (IOException)
            {
                throw;
            }
            return bos.ToArray();
        }
    }
}