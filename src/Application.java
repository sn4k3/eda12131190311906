import java.lang.reflect.Method;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.ArrayList;
import java.util.Random;

/**
 * @author Tiago Conceição Nº 11903
 * @author Gonçalo Lampreia Nº 11906
 */
public class Application {
	/**
	 * Number of tests to realize with sorting algorithms
	 */
	public final static byte NUMBER_OF_TESTS = 15;
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
	 * 
	 * @param args
	 *            Arguments
	 */
	public static void main(String[] args) {
		Application.Setup();
		Application.runAlgorithms();
	}

	/**
	 * Run common tasks to setup the application
	 */
	public static void Setup() {
		Application.reports = new ArrayList<Report>();
		if (Application.GNUPLOT_PATH == null) {
			Application.GNUPLOT_PATH = SystemHelper.getProgramFilesX86Path();
			if (Application.GNUPLOT_PATH != "") {
				Application.GNUPLOT_PATH += "gnuplot\\bin";
			}
		}
	}

	/**
	 * Get a report by name
	 * 
	 * @param name
	 *            Report name
	 * @return Report, null if no exists
	 */
	public static Report getReport(String name) {
		for (Report report : Application.reports) {
			if (report.getName().equals(name)) {
				return report;
			}
		}
		return null;
	}

	/**
	 * Run algorithms, measure execution time and report to a file
	 */
	public static void runAlgorithms() {
		// Create a list with multiple arrays holding random numbers
		List<int[]> testArray = new ArrayList<int[]>(
				Application.NUMBER_OF_TESTS);
		for (int i = 1; i <= Application.NUMBER_OF_TESTS; i++) {
			int size = (int) Math.min(i * 10L * ((i - 1) * 2L),
					Integer.MAX_VALUE);
			if (size == 0) {
				size = i * 10;
			}
			int maxvalue = (int) Math.min(size * 25, Integer.MAX_VALUE);
			if (maxvalue == 0) {
				maxvalue = i * 50;
			}
			testArray.add(SystemHelper.randomIntegerArray(size, maxvalue));
		}
		List<int[]> testArrayCopy = SystemHelper.cloneListIntArray(testArray);
		// Small array
		/*
		 * int A[] = SystemHelper.randomIntegerArray(15, 500); int AA[] =
		 * A.clone();
		 * 
		 * // Big array int B[] = SystemHelper.randomIntegerArray(1000,
		 * 1000000); int BB[] = B.clone();
		 */

		Report reportInsertion = Application.runOneAlgorithm("Insertion", testArrayCopy);
		testArrayCopy = SystemHelper.cloneListIntArray(testArray);
		Report reportBubble = Application.runOneAlgorithm("Bubble", testArrayCopy);
		testArrayCopy = SystemHelper.cloneListIntArray(testArray);
		Report reportMaxheap = Application.runOneAlgorithm("Maxheap", testArrayCopy);
		testArrayCopy = SystemHelper.cloneListIntArray(testArray);
		Report reportMerge = Application.runOneAlgorithm("Merge", testArrayCopy);
		testArrayCopy = SystemHelper.cloneListIntArray(testArray);
		Report reportQuick = Application.runOneAlgorithm("Quick", testArrayCopy);
		testArrayCopy = SystemHelper.cloneListIntArray(testArray);
	}

	/**
	 * Run a algorithm and log execution
	 * 
	 * @param classname
	 *            Class name
	 * @param method
	 *            Method name (sort)
	 * @param A
	 *            List with arrays to sort
	 * @return Report log
	 */
	public static Report runOneAlgorithm(String classname, String method,
			List<int[]> A) {
		try {
			Class<?> c = Class.forName(classname);
			Method m = c.getDeclaredMethod(method, int[].class);
			m.setAccessible(true);

			Report report = new Report(classname);
			report.addPlotColumn("Sort");
			report.addPlotColumn("\t\tSort-sorted");
			Application.reports.add(report);
			int count = 1;
			for(int[] intA : A)
			{
				report.addComment("");
				report.addComment("Array("+intA.length+") "+count+": " + Arrays.toString(intA));
				
	
				Profiler profiler = report.addProfiler("Sort "+count);
				m.invoke(null, intA);
				profiler.stop();
				report.addComment("Sorted array "+
						count+
						": "+ 
						Arrays.toString(intA));
	
				profiler = report.addProfiler("Sort-Sorted "+count);
				Application.reports.add(report);
				m.invoke(null, intA);
				profiler.stop();
				report.addComment("Sorted-sorted array "+
						count+
						": "+ 
						Arrays.toString(intA));
				count++;
			}
			
			report.writeToFile();

			return report;
		} catch (Exception e) {
			System.err.println("Error: " + e.getMessage());
		}
		return null;
	}

	/**
	 * Run a algorithm and log execution
	 * 
	 * @param classname
	 *            Class name
	 * @param method
	 *            Method name (sort)
	 * @param A
	 *            Array to sort
	 * @return Report log
	 */
	public static Report runOneAlgorithm(String classname, String method,
			int A[]) {
		List<int[]> arrayList = new ArrayList<int[]>(1);
		arrayList.add(A);
		return Application.runOneAlgorithm(classname, method, arrayList);
	}

	/**
	 * Run a algorithm and log execution
	 * 
	 * @param classname
	 *            Class name
	 * @param A
	 *            List with arrays to sort
	 * @return Report log
	 */
	public static Report runOneAlgorithm(String classname, List<int[]> A) {
		return Application.runOneAlgorithm(classname, "sort", A);
	}

	/**
	 * Run a algorithm and log execution
	 * 
	 * @param classname
	 *            Class name
	 * @param A
	 *            Array to sort
	 * @return Report log
	 */
	public static Report runOneAlgorithm(String classname, int A[]) {
		return Application.runOneAlgorithm(classname, "sort", A);
	}

}
