import java.security.SecureRandom;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;

import com.sun.servicetag.SystemEnvironment;

/**
 * @author Tiago Conceição Nº 11903
 * @author Gonçalo Lampreia Nº 11906
 */
public class SystemHelper {
	
	/**
	 * Get program files X86 path, windows only
	 * @return Program files X86 path
	 */
	public static String getProgramFilesX86Path()
	{
		if(!SystemHelper.isWindows())
		{
			return "";
		}

		return SystemHelper.archBits() == 64 ? 
				System.getenv("ProgramFiles(X86)") : 
				System.getenv("ProgramFiles");
	}
	
	/**
	 * Get system bits
	 * @return System bits, 32 or 64
	 */
	public static byte archBits()
	{
		SystemEnvironment env = SystemEnvironment.getSystemEnvironment();
		final String bits = env.getOsArchitecture();
		if(bits.indexOf("64") >= 0) return 64;
		return 32;
	}
 
	/**
	 * Is windows OS
	 * @return True if windows, otherwise false
	 */
	public static boolean isWindows()
	{
		String OS = System.getProperty("os.name").toLowerCase();
		return (OS.indexOf("win") >= 0);
	}
 
	/**
	 * Is mac OS
	 * @return True if mac, otherwise false
	 */
	public static boolean isMac()
	{
		String OS = System.getProperty("os.name").toLowerCase();
		return (OS.indexOf("mac") >= 0);
	}
 
	/**
	 * Is unix OS
	 * @return True if unix, otherwise false
	 */
	public static boolean isUnix()
	{
		String OS = System.getProperty("os.name").toLowerCase();
		return (OS.indexOf("nix") >= 0 || OS.indexOf("nux") >= 0 || OS.indexOf("aix") > 0 );
	}
 
	/**
	 * Is solaris OS
	 * @return True if solaris, otherwise false
	 */
	public static boolean isSolaris()
	{
		String OS = System.getProperty("os.name").toLowerCase();
		return (OS.indexOf("sunos") >= 0);
	}
	
	/**
	 * Generate a random integer array
	 * @param size Size of array
	 * @param maxValue Max value for random numbers
	 * @return An array populated with random values
	 */
	public static int[] randomIntegerArray(int size, int maxValue)
	{
		Random rand = new SecureRandom();
		int A[] = new int[size];
		for(int i = 0; i < size; i++)
		{
			int number = rand.nextInt(maxValue) + 1;
			A[i] = number;
		}
		return A;
	}
	
	/**
	 * Clone an List<int[]>
	 * @param list List to clone
	 * @return Cloned list
	 */
	public static List<int[]> cloneListIntArray(List<int[]> list)
	{
		List<int[]> newList = new ArrayList<int[]>();
		for(int[] A : list)
		{
			newList.add(A.clone());
		}
		return newList;
	}
}
