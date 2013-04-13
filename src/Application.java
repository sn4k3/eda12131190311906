import java.lang.reflect.Method;
import java.util.Arrays;
import java.util.List;
import java.util.ArrayList;
import java.util.Random;


/**
 * @author Tiago Conceição Nº 11903
 * @author Gonçalo Lampreia Nº 11906
 */
public class Application {
	/**
	 * Where to save reports to load with gnuplot
	 */
	public final static String REPORTS_PATH = "Report";
	
	/**
	 * Gnuplot executable path
	 */
	public static String GNUPLOT_PATH = null;
	
	/**
	 * Collection of reports
	 */
	private static List<Report> reports;
	
	/**
	 * Main app function
	 * @param args Arguments
	 */
	public static void main(String[] args) 
	{
		Application.Setup();
		Application.runAlgorithms();
	}
	
	/**
	 * Run common tasks to setup the application
	 */
	public static void Setup()
	{
		Application.reports = new ArrayList<Report>();
		if(Application.GNUPLOT_PATH == null)
		{
			Application.GNUPLOT_PATH = SystemHelper.getProgramFilesX86Path();
			if(Application.GNUPLOT_PATH != "")
			{
				Application.GNUPLOT_PATH += "gnuplot\\bin";
			}
		}
	}
	
	/**
	 * Get a report by name
	 * @param name Report name
	 * @return Report, null if no exists
	 */
	public static Report getReport(String name)
	{
		for (Report report : Application.reports) 
		{
			if(report.getName().equals(name))
			{
				return report;
			}
		}
		return null;
	}
	
	
	
	/**
	 * Run algorithms, measure execution time and report to a file
	 */
	public static void runAlgorithms()
	{
		List<int[]> testArray = new ArrayList<int[]>();
		// Small array
		int A[] = SystemHelper.randomIntegerArray(15, 500);
		int AA[] = A.clone();
		
		// Big array
		int B[] = SystemHelper.randomIntegerArray(1000, 1000000);
		int BB[] = B.clone();
		
		Report reportInsertion = Application.runOneAlgorithm("Insertion", A);
		A = AA.clone();
		Report reportBubble = Application.runOneAlgorithm("Bubble", A);
		A = AA.clone();
		Report reportMaxheap = Application.runOneAlgorithm("Maxheap", A);
		A = AA.clone();
		Report reportMerge = Application.runOneAlgorithm("Merge", A);
		A = AA.clone();
		Report reportQuick = Application.runOneAlgorithm("Quick", A);
		A = AA.clone();
	}
	
	/**
	 * Run a algorithm and log execution
	 * @param classname Class name
	 * @param method Method name (sort)
	 * @param A Array to sort
	 * @return Report log
	 */
	public static Report runOneAlgorithm(String classname, String method, int A[])
	{
		try
	    {
			Class<?> c = Class.forName(classname);
			Method m = c.getDeclaredMethod(method, int[].class);
			m.setAccessible(true);

			Report report = new Report(classname);
			report.addComment("Array: " + Arrays.toString(A));
			Application.reports.add(report);

			Profiler profiler = report.addProfiler("Sort");
			m.invoke(null, A);
			profiler.stop();
			report.addComment("Sorted array: " + Arrays.toString(A));
			
			profiler = report.addProfiler("Sort-Sorted");
			Application.reports.add(report);
			m.invoke(null, A);
			profiler.stop();
			report.addComment("Sorted-sorted array: " + Arrays.toString(A));
			report.writeToFile();

			return report;
	    }
	    catch (Exception e)
	    {
	    	System.err.println("Error: " + e.getMessage());
	    }
		return null;
	}
	
	/**
	 * Run a algorithm and log execution
	 * @param classname Class name
	 * @param A Array to sort
	 * @return Report log
	 */
	public static Report runOneAlgorithm(String classname, int A[])
	{
		return Application.runOneAlgorithm(classname, "sort", A);
	}

}
