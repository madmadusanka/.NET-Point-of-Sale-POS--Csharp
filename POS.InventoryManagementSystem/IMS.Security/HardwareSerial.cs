using System.Management;

namespace IMS.Security
{
    public class HardwareSerial
    {
        public static string GetHardDriveSerialNumber()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

                foreach (ManagementObject diskDrive in searcher.Get())
                {
                    return diskDrive["SerialNumber"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return "Serial Number Not Found";
        }
    }
}