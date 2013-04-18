import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.lang.reflect.Method;
import java.util.Arrays;
import java.util.List;
import java.util.ArrayList;

/**
 * @author Tiago Conceição Nº 11903
 * @author Gonçalo Lampreia Nº 11906
 */
public class Application {
	public final static String[] ALGORTIHMS = new String[] {"Insertion",
															"Bubble",
															"Heap",
															"Merge",
															"Quick",
															"Bucket",
															"Counting",
															"Comb",
															"Selection",
															"Shell"};
	/**
	 * Number of tests to realize with sorting algorithms
	 */
	public final static byte NUMBER_OF_TESTS = 15;
	/**
	 * Where to save reports to load with gnuplot
	 */
	public final static String REPORTS_PATH = "Report/plot";

	/**
	 * Gnuplot executable path
	 */
	public static String GNUPLOT_PATH = null;
	
	/**
	 * GNUPLOT Graf generator file
	 */
	public static String GNUPLOT_GENERATOR_FILE = "plot_results";

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
		Application.generateGnuplotFiles();
	}

	/**
	 * Run common tasks to setup the application
	 */
	public static void Setup() {
		Application.reports = new ArrayList<Report>();
		if (Application.GNUPLOT_PATH == null) {
			Application.GNUPLOT_PATH = SystemHelper.getProgramFilesX86Path();
			if (Application.GNUPLOT_PATH != "") {
				Application.GNUPLOT_PATH += "\\gnuplot\\bin\\gnuplot.exe";
			}
			else // No windows
			{
				Application.GNUPLOT_PATH = "gnuplot";
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
		int size = 10;
		for (int i = 1; i <= Application.NUMBER_OF_TESTS; i++) {
			/*int size = (int) Math.min(i * 10L * ((i - 1) * 50L),
					Integer.MAX_VALUE);*/
			size = Math.min(size*2,	Integer.MAX_VALUE);
			if (size == 0) {
				size = i * 10;
			}
			int maxvalue = (int) Math.min(size * 5, Integer.MAX_VALUE);
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
		
		for(int i = 0; i < Application.ALGORTIHMS.length; i++)
		{
			Report report = Application.runOneAlgorithm(Application.ALGORTIHMS[i], testArrayCopy);
			testArrayCopy = SystemHelper.cloneListIntArray(testArray);
		}
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
			report.addPlotColumn("Sort-sorted");
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
	
				Profiler profiler1 = report.addProfiler("Sort-Sorted "+count);
				Application.reports.add(report);
				m.invoke(null, intA);
				profiler1.stop();
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
	
	private static void generateGnuplotFiles() 
	{
		try {
			File file = new File(Application.REPORTS_PATH, 
					Application.GNUPLOT_GENERATOR_FILE);
			

			FileWriter fstream = new FileWriter(file.getPath()+
					(SystemHelper.isWindows() ? ".bat" : ".sh"));
			BufferedWriter out = new BufferedWriter(fstream);
			
			out.write("@echo off\n" +
					"title \"Relatorio de grafos com GNUPLOT\"\n" +
					"set GNUPLOT_PATH=\""+Application.GNUPLOT_PATH+"\"\n");
			for(int i = 0; i < Application.ALGORTIHMS.length; i++)
			{
				out.write("echo Running "+Application.ALGORTIHMS[i]+" sort plot\n"+
						"%GNUPLOT_PATH% -p \""+Application.ALGORTIHMS[i]+".plt\"\n");
			}
			out.write("\npause");
			
			out.close();
			fstream.close();
		} catch (Exception e) {
			System.err.println(e.getMessage());
		}
	}

}
