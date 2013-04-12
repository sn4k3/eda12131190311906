import java.util.List;
import java.util.ArrayList;


/**
 * @author Tiago
 *
 */
public class Application {
	public final static String REPORTS_PATH = "Report";
	public static String GNUPLOT_PATH = null;
	
	/**
	 * Collection of reports
	 */
	private static List<Report> reports;
	
	/**
	 * @param args
	 */
	public static void main(String[] args) 
	{
		Application.Setup();
		
		
		/*Profiler prof = new Profiler();
		prof.stop();
		prof.printToConsole("Hello: ");
		prof.printToConsole("Hello: ", false);*/
		Report report = new Report("test");
		Profiler profiler = report.addProfiler("execution now");
		
		Application.reports.add(report);
		profiler.stop();
		report.writeToFile();
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

}
